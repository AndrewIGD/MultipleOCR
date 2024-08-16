namespace FolderPDFOCR_2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.console = new System.Windows.Forms.RichTextBox();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.sourceButton = new System.Windows.Forms.Button();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.destinationButton = new System.Windows.Forms.Button();
            this.progressBarText = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.threadCounter = new System.Windows.Forms.NumericUpDown();
            this.threadCounterLabel = new System.Windows.Forms.Label();
            this.overwriteFiles = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.threadCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(13, 250);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(344, 99);
            this.console.TabIndex = 0;
            this.console.Text = "";
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(9, 9);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(73, 13);
            this.sourceLabel.TabIndex = 1;
            this.sourceLabel.Text = "Source Folder";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 191);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(344, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 2;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(12, 25);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(318, 20);
            this.sourceTextBox.TabIndex = 3;
            // 
            // sourceButton
            // 
            this.sourceButton.Image = ((System.Drawing.Image)(resources.GetObject("sourceButton.Image")));
            this.sourceButton.Location = new System.Drawing.Point(336, 24);
            this.sourceButton.Name = "sourceButton";
            this.sourceButton.Size = new System.Drawing.Size(20, 20);
            this.sourceButton.TabIndex = 4;
            this.sourceButton.UseVisualStyleBackColor = true;
            this.sourceButton.Click += new System.EventHandler(this.sourceButton_Click);
            // 
            // destinationTextBox
            // 
            this.destinationTextBox.Location = new System.Drawing.Point(12, 64);
            this.destinationTextBox.Name = "destinationTextBox";
            this.destinationTextBox.Size = new System.Drawing.Size(318, 20);
            this.destinationTextBox.TabIndex = 6;
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Location = new System.Drawing.Point(9, 48);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(92, 13);
            this.destinationLabel.TabIndex = 5;
            this.destinationLabel.Text = "Destination Folder";
            // 
            // destinationButton
            // 
            this.destinationButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.destinationButton.Image = ((System.Drawing.Image)(resources.GetObject("destinationButton.Image")));
            this.destinationButton.Location = new System.Drawing.Point(336, 63);
            this.destinationButton.Name = "destinationButton";
            this.destinationButton.Size = new System.Drawing.Size(20, 20);
            this.destinationButton.TabIndex = 7;
            this.destinationButton.UseVisualStyleBackColor = true;
            this.destinationButton.Click += new System.EventHandler(this.destinationButton_Click);
            // 
            // progressBarText
            // 
            this.progressBarText.AutoSize = true;
            this.progressBarText.Location = new System.Drawing.Point(10, 175);
            this.progressBarText.Name = "progressBarText";
            this.progressBarText.Size = new System.Drawing.Size(71, 13);
            this.progressBarText.TabIndex = 8;
            this.progressBarText.Text = "Progress: 0/0";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(14, 221);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(343, 23);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // threadCounter
            // 
            this.threadCounter.Location = new System.Drawing.Point(13, 103);
            this.threadCounter.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.threadCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadCounter.Name = "threadCounter";
            this.threadCounter.Size = new System.Drawing.Size(88, 20);
            this.threadCounter.TabIndex = 10;
            this.threadCounter.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // threadCounterLabel
            // 
            this.threadCounterLabel.AutoSize = true;
            this.threadCounterLabel.Location = new System.Drawing.Point(12, 87);
            this.threadCounterLabel.Name = "threadCounterLabel";
            this.threadCounterLabel.Size = new System.Drawing.Size(46, 13);
            this.threadCounterLabel.TabIndex = 11;
            this.threadCounterLabel.Text = "Threads";
            // 
            // overwriteFiles
            // 
            this.overwriteFiles.AutoSize = true;
            this.overwriteFiles.Location = new System.Drawing.Point(14, 129);
            this.overwriteFiles.Name = "overwriteFiles";
            this.overwriteFiles.Size = new System.Drawing.Size(134, 17);
            this.overwriteFiles.TabIndex = 13;
            this.overwriteFiles.Text = "Overwrite Existing Files";
            this.overwriteFiles.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 361);
            this.Controls.Add(this.overwriteFiles);
            this.Controls.Add(this.threadCounterLabel);
            this.Controls.Add(this.threadCounter);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.progressBarText);
            this.Controls.Add(this.destinationButton);
            this.Controls.Add(this.destinationTextBox);
            this.Controls.Add(this.destinationLabel);
            this.Controls.Add(this.sourceButton);
            this.Controls.Add(this.sourceTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.console);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(384, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(384, 400);
            this.Name = "MainForm";
            this.Text = "MultipleOCR";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.threadCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.Button sourceButton;
        private System.Windows.Forms.TextBox destinationTextBox;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.Button destinationButton;
        private System.Windows.Forms.Label progressBarText;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.NumericUpDown threadCounter;
        private System.Windows.Forms.Label threadCounterLabel;
        private System.Windows.Forms.CheckBox overwriteFiles;
    }
}

