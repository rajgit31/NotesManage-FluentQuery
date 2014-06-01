using System;
using System.Configuration;
using System.Windows.Forms;
using NotesManager.Infrastructure.DependencyInjection;

namespace NotesManager.WindowsForms.UI
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
            Bootstrapper.Initialise();
            Bootstrapper.RegisterType(typeof(INotesManagerView), typeof(FrmNotes));
            var formToRun = Bootstrapper.Resolve(typeof (INotesManagerView));

            Application.Run((FrmNotes)formToRun);
        }

        
    }
}
