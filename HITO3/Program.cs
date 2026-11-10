using System;
using System.Windows.Forms;
using SistemaLegadoApp.Views;

namespace SistemaLegadoApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuForm()); 
        }
    }
}