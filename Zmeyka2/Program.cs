using System;
using System.Windows.Forms;
using Zmeyka2.Logic;

namespace Zmeyka2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            GameControler GC = new GameControler();
            //Presenter presenter = new Presenter(form, GC);
            
            Application.Run(form);
        }
    }

}
