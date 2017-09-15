using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RPG_Manager.WPF
{
    public class Positioning
    {
        public static void openNewWindow(Window newW, Window oldW)
        {
            newW.Left = oldW.Left;
            newW.Top = oldW.Top;
            newW.Width = oldW.Width;
            newW.Height = oldW.Height;
            newW.Show();
            oldW.Hide();
        }
    }
}
