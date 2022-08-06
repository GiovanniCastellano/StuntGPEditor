using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StuntGPEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            FileManager fileManager = new FileManager();
            fileManager.Write();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            FileManager fileManager = new FileManager();
            
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select \"setup.wad\"";
            dialog.Filter = "(*.wad)|*.wad";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                CustomConsole.WriteMessageLine(dialog.FileName);
                fileManager.Read(dialog.FileName);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "StuntGPEditor made by Giovanni Castellano\n" +
                "Github repository: https://github.com/GiovanniCastellano/StuntGPEditor\n\n" +
                "- The editor can automatically load the correct file if it is run from the main game directory," +
                " otherwise, click the open button to select the file \"wads/setup.wad\"\n\n" +
                "- Changes must respect the byte length of the original file, this means values on the same row cannot be changed in " +
                "length\n(ex: 45000 cannot become 4500, but it can become 20000 because they share the same amount of digits, " +
                "furthermore, let's take 45000 as an example: if that value is modified to 4500, and on the same row, another value, " +
                "let's say 120, is modified to 1200, the total digit count is respected and the editor will allow such change)\n\n" +
                "- Manually modifying the file \"setup.wad\" can lead to corruption, this editor will detect if the file has the correct" +
                "byte count when opening it, and will refuse to open and modify it if it has signs of corruption: please check the GitHub" +
                "page of this project to get a working \"setup.wad\" file",
                "StuntGPEditor Help window");
        }
    }
}
