using System;
using System.Windows.Forms;

namespace ClipSync {
    static class Program {

        internal static ClipSyncControlForm loginSignUpForm { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginSignUpForm = new ClipSyncControlForm();
            Application.Run(loginSignUpForm);
        }
    }
}
