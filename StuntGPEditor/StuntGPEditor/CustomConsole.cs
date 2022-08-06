using System.Drawing;
using System.Windows.Forms;

namespace StuntGPEditor
{
    public static class CustomConsole
    {
        public static void WriteMessage(string text)
        {
            Write(text, Program.mainForm.consoleRichTextBox.ForeColor);
        }
        public static void WriteMessageLine(string text)
        {
            WriteLine(text, Program.mainForm.consoleRichTextBox.ForeColor);
        }

        public static void WriteError(string text)
        {
            Write(text, Color.Red);
        }
        public static void WriteErrorLine(string text)
        {
            WriteLine(text, Color.Red);
        }

        public static void WriteWarning(string text)
        {
            Write(text, Color.Yellow);
        }
        public static void WriteWarningLine(string text)
        {
            WriteLine(text, Color.Yellow);
        }

        private static void Write(string text, Color color)
        {
            RichTextBox box = Program.mainForm.consoleRichTextBox;
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        private static void WriteLine(string text, Color color)
        {
            Write(text + "\n", color);
        }
    }
}
