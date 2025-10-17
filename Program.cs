using System;
using System.Windows.Forms;

namespace OOP_finalProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Test Singleton pattern (có thể comment out khi không cần test)
            SingletonTest.TestSingletonPattern();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainInterface());
        }
    }
}
