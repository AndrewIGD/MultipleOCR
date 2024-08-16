using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace FolderPDFOCR_2
{
    public static class Logger
    {
        private static RichTextBox textBox;

        public static void Log(string text, LogType logType)
        {
            switch(logType)
            {
                case LogType.Info:
                    {
                        if(textBox.InvokeRequired)
                            textBox.Invoke(new MethodInvoker(delegate { textBox.AppendText($"[INFO] {text}\n"); }));
                        else textBox.AppendText($"[INFO] {text}\n");
                        break;
                    }

                case LogType.Warning:
                    {
                        if (textBox.InvokeRequired)
                            textBox.Invoke(new MethodInvoker(delegate { textBox.AppendText($"[WARNING] {text}\n", System.Drawing.Color.Orange); }));
                        else textBox.AppendText($"[WARNING] {text}\n", System.Drawing.Color.Orange);
                        break;
                    }

                case LogType.Error:
                    {
                        if (textBox.InvokeRequired)
                            textBox.Invoke(new MethodInvoker(delegate { textBox.AppendText($"[ERROR] {text}\n", System.Drawing.Color.Red); }));
                        else textBox.AppendText($"[ERROR] {text}\n", System.Drawing.Color.Red);
                        break;
                    }
            }

            if (textBox.InvokeRequired)
                textBox.Invoke(new MethodInvoker(delegate {
                    textBox.SelectionStart = textBox.Text.Length;
                    textBox.ScrollToCaret();
                }));
            else
            {
                textBox.SelectionStart = textBox.Text.Length;
                textBox.ScrollToCaret();
            }
        }

        public static void Clear()
        {
            textBox.Clear();
        }

        public static void Subscribe(RichTextBox richTextBox) => textBox = richTextBox;
    }

    public enum LogType
    {
        Info,
        Warning,
        Error
    }
}
