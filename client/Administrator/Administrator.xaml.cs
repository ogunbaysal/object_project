using client.Administrator.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace client.Administrator
{
    /// <summary>
    /// Interaction logic for Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {
        public Window ChildWindow;
        public Administrator()
        {
            InitializeComponent();
            setChild(new LoginPage());
        }
        protected void setChild(Window window)
        {
            ChildWindow = window;
            panelContent.Children.Clear();

            object content = ChildWindow.Content;
            ChildWindow.Content = null;
            ChildWindow.Close();

            this.panelContent.Children.Add(content as UIElement);

        }
    }
}
