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
            //Allow for flexible heights
            //newW.Height = oldW.Height;
            newW.Show();
            oldW.Hide();
        }
    }
}