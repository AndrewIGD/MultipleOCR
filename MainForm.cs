using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FolderPDFOCR_2
{
    public partial class MainForm : Form
    {
        private bool _processingOCR = false;
        private int _processedFiles = 0;
        private int _totalFiles = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void sourceButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if(Directory.Exists(sourceTextBox.Text))
                    fbd.SelectedPath = sourceTextBox.Text;

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    sourceTextBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void destinationButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (Directory.Exists(destinationTextBox.Text))
                    fbd.SelectedPath = destinationTextBox.Text;

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    destinationTextBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!_processingOCR)
            {
                StartOCR();
                return;
            }

            StopOCR();
            Logger.Log($"OCR operation cancelled", LogType.Info);
        }

        private void StartOCR()
        {
            var sourceFolder = sourceTextBox.Text;
            var destinationFolder = destinationTextBox.Text;

            if (!Directory.Exists(sourceFolder))
            {
                MessageBox.Show("Please select a valid source folder", "Invalid Source Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(destinationFolder))
            {
                MessageBox.Show("Please select a valid destination folder", "Invalid Destination Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Logger.Clear();

            var files = Directory.GetFiles(sourceFolder).Where(x => Path.GetExtension(x) == ".pdf").ToArray();

            if(!overwriteFiles.Checked)
                files = files.Where(x =>
                {
                    bool res = !File.Exists(MultipleOCR.Utils.GetFileDestination(x, destinationFolder));
                    if (!res)
                        Logger.Log($"Skipping {Path.GetFileName(x)} since it has already been processed...", LogType.Warning);

                    return res;
                }).ToArray();

            if (files.Length == 0)
            {
                MessageBox.Show("No files found found for OCR. Either the source folder doesn't have pdf files or they have been skipped because they have already been processed. Enable 'Overwrite Existing Files' to overwrite the files on the destination folder.", "No files found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _processingOCR = true;

            Array.Sort(files, (x, y) => String.Compare(y, x));

            _processedFiles = 0;
            _totalFiles = files.Length;

            progressBar.Value = 0;
            progressBar.Maximum = files.Length;
            progressBarText.Text = $"Progress 0/{_totalFiles}";
            startButton.Text = "Stop";
            sourceButton.Enabled = destinationButton.Enabled = sourceTextBox.Enabled = destinationTextBox.Enabled = threadCounter.Enabled = false;

            OCR.Folder(files, destinationFolder, (int)threadCounter.Value, OnProgressUpdate);
        }

        private void OnProgressUpdate()
        {
            _processedFiles++;
            if (progressBarText.InvokeRequired)
            {
                progressBarText.Invoke(new MethodInvoker(delegate { progressBarText.Text = $"Progress: {_processedFiles}/{_totalFiles}"; }));
                progressBar.Invoke(new MethodInvoker(delegate { progressBar.PerformStep(); }));
            }
            else
            {
                progressBarText.Text = $"Progress: {_processedFiles}/{_totalFiles}";
                progressBar.PerformStep();
            }

            if(_processedFiles == _totalFiles)
                StopOCR();
        }

        private void StopOCR()
        {
            OCR.Cancel();
            _processingOCR = false;
            if (startButton.InvokeRequired)
            {
                startButton.Invoke(new MethodInvoker(delegate { startButton.Text = "Start"; }));
                sourceButton.Invoke(new MethodInvoker(delegate { sourceButton.Enabled = true; }));
                destinationButton.Invoke(new MethodInvoker(delegate { destinationButton.Enabled = true; }));
                sourceTextBox.Invoke(new MethodInvoker(delegate { sourceTextBox.Enabled = true; }));
                destinationTextBox.Invoke(new MethodInvoker(delegate { destinationTextBox.Enabled = true; }));
                threadCounter.Invoke(new MethodInvoker(delegate { threadCounter.Enabled = true; }));
            }
            else
            {
                startButton.Text = "Start";
                sourceButton.Enabled = destinationButton.Enabled = sourceTextBox.Enabled = destinationTextBox.Enabled = threadCounter.Enabled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Logger.Subscribe(console);
        }
    }
}
