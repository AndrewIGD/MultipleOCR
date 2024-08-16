using System.Drawing;
using System.Windows.Forms;

namespace FolderPDFOCR_2
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            if(box.InvokeRequired)
            {
                box.Invoke(new MethodInvoker(delegate
                {
                    AppendText(box, text, color);
                }));

                return;
            }

            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
