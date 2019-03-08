using System;
using System.Windows.Forms;

namespace BarkodSistemTekstil
{
    static public class Program
    {
        
        public static Form1 f1;
        
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Startup());
        }

        public static Form Startup()
        {
            f1 = new Form1();
            return f1;
        }
    }
}
