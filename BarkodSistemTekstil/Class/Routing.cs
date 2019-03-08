using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodSistemTekstil.Class
{
    public static class Routing
    {
        public static void AddPage(UserControl uc)
        {
            Program.f1.pnlContainer.Controls.Clear();
            Program.f1.pnlContainer.Controls.Add(uc);


        }
        public static void Clear()
        {
            Program.f1.pnlContainer.Controls.Clear();
        }


    }
}
