using client.Api;
using client.Api.Core;
using client.Components.CategoryView;
using client.Helpers;
using client.Model;
using client.View.Home;
using client.View.ProductListing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using client.Utils;

namespace client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public UserControl ChildContent;
        CategoryAPI _categoryApi;
        public MainWindow()
        {
            InitializeComponent();
            Router.Initialize(this);
            _categoryApi = new CategoryAPI();
            setCategories();
            this.ChildContent = new Home();
            this.DataContext = this;
        }
        private void setCategories()
        {
            var result = _categoryApi.GetCategories();
            if(result.Count > 0)
            {
                var list = JArrayToList.Convert<Category>(result.Data);
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
            CategoryViewCanvas.HorizontalAlignment = HorizontalAlignment.Center;
            view.Width = CategoryViewCanvas.Width;
            CategoryViewCanvas.Height = view.Height;
            CategoryViewCanvas.Visibility = Visibility.Visible;
            CategoryViewCanvas.Name = "CategoryViewCanvas";
            CategoryViewCanvas.Children.Add(view);

        }
        private void View_ChildCategoryClicked(object sender, Components.CategoryView.EventArgs e)
        {
            long clickedChildCategoryId = e.ChildCategoryId;
            var content = new ProductListing(new ProductFilter() { ChildCategoryId = clickedChildCategoryId });
            this.SetPage(content);
        }
        public void SetPage(UserControl content)
        {
            pageContent.Children.Clear();
            pageContent.Width = content.Width;
            content.Height = pageContent.Height;
            pageContent.Children.Add(content);
        }
        private void RouteEvent_OnRouteChanged(object src, Helpers.EventArgs args)
        {
            this.SetPage(args.NewControl);
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
