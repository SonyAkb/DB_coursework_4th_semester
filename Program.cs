using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseworkDB
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        public static LoginForm MainLoginForm { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainLoginForm = new LoginForm();
            Application.Run(MainLoginForm);

        }

        public static void ExitApplication()
        {
            // Принудительно завершаем приложение
            Environment.Exit(0);
        }
    }
}
