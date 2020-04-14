using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace client.Utils
{
    public class Router
    {
        private static Router _instance;
        private MainWindow mainWindow;
        public static Router Initialize(MainWindow main)
        {
            if(_instance != null) throw new Exception("Already Initialized!");
            _instance = new Router(main);
            return _instance;
        }
        public static Router GetInstance()
        {
            return _instance;
        }

        private Router(MainWindow window)
        {
            mainWindow = window;
        }

        public void GoView(UserControl uc)
        {
            mainWindow.SetPage(uc);
        }
        
    }
}
