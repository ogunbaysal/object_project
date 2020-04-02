using client.Api;
using client.Api.Core;
using client.Components.CategoryView;
using client.Helpers;
using client.Model;
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
        CategoryAPI _categoryApi;
        public MainWindow()
        {
            InitializeComponent();
            _categoryApi = new CategoryAPI();
            setCategories();
            
        }
        private void setCategories()
        {
            var result = _categoryApi.GetCategories();
            if(result.Count > 0)
            {
                var list = JObjectToObject.ConvertList<Category>(result.Data);
                MainCategoriesPanel.Children.Clear();
                foreach(var item in list)
                {
                    var label = new Label();
                    label.Content = item.Title;
                    label.FontSize = 20;
                    label.Tag = item.Id;
                    label.MouseLeftButtonUp += MainCategoryOnClicked;
                    MainCategoriesPanel.Children.Add(label);
                }
            }
        }

        private void MainCategoryOnClicked(object sender, MouseButtonEventArgs e)
        {
            var label = (Label)sender;
            var view = new CategoryView((long)label.Tag);
            view.ChildCategoryClicked += View_ChildCategoryClicked;
            CategoryViewCanvas.Height = view.Height;
            CategoryViewCanvas.Width = view.Width;
            CategoryViewCanvas.Visibility = Visibility.Visible;
            CategoryViewCanvas.Name = "CategoryViewCanvas";
            CategoryViewCanvas.Children.Add(view);

        }

        private void View_ChildCategoryClicked(object sender, Components.CategoryView.EventArgs e)
        {
            
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

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(!CategoryViewCanvas.IsMouseOver && CategoryViewCanvas.Visibility == Visibility.Visible)
            {
                CategoryViewCanvas.Visibility = Visibility.Hidden;                
            }
        }
    }
}
