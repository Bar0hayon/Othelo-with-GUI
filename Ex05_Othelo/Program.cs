using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ex05_Othelo
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameManager gameManager = new GameManager();
            gameManager.StartGame();
        }
    }
}
