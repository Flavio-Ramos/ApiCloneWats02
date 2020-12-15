using System;
using System.Windows.Forms;

namespace TelasDeTeste
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new Tela1());
            Application.Run(new LoginTeste());
        }
    }
}
