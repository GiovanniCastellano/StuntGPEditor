using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StuntGPEditor
{
    static internal class Program
    {
        public static Form1 mainForm;
        public static BindingList<Car> carList;
        public static string setupWadPath = "";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new Form1();
            FileManager fileManager = new FileManager();
            fileManager.Read("wads/setup.wad");

            Application.Run(mainForm);
        }
    }
}
