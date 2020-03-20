using client.Components.CategoryView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Window ChildWindow;
        public MainWindow()
        {
            InitializeComponent();
        }

        protected void setPage(Window window)
        {
            ChildWindow = window;
           this.pageContent.Children.Clear();

            object content = ChildWindow.Content;
            ChildWindow.Content = null;
            ChildWindow.Close();
            this.pageContent.Children.Add(content as UIElement);
        }

    }
}
