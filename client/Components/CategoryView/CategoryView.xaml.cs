using client.Api;
using client.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace client.Components.CategoryView
{
    public class EventArgs
    {
        public long ChildCategoryId { get; set; }
    }
    /// <summary>
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl
    {
        private CategoryAPI _categoryApi;

        public event EventHandler<EventArgs> ChildCategoryClicked;
        public List<SubCategory> SubCategories { get; set; }
        public int MainGridColumnCount = 0;

        public CategoryView(long id)
        {
            InitializeComponent();
            _categoryApi = new CategoryAPI();
            this.SubCategories = this.getSubCategories(id);
            DataContext = this;
            MainGridColumnCount = SubCategories.Count;
            // createDynamicWpfGrid(id);
        }
        private List<SubCategory> getSubCategories(long categoryId)
        {
            var data = _categoryApi.GetSubCategories(categoryId);
            var list = new List<SubCategory>();
            var arr = ((JArray)data.Data).Children();
            foreach(var i in arr)
            {
                var item = i.ToObject<SubCategory>();
                item.ChildCategories = getChildCategories(item.Id);
                list.Add(item);
            }
            return list;
        }
        private List<ChildCategory> getChildCategories(long subCategoryId)
        {
            var data = _categoryApi.GetChildCategories(subCategoryId);
            var list = new List<ChildCategory>();
            var arr = ((JArray)data.Data).Children();
            foreach (var i in arr)
            {
                var item = i.ToObject<ChildCategory>();
                list.Add(item);
            }
            return list;

        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (TextBlock)sender;
            var id = (long)item.Tag;
            var args = new EventArgs()
            {
                ChildCategoryId = id
            };
            Dispatcher.BeginInvoke(new EventHandler<EventArgs>(ChildCategoryClicked), this, args);
        }
    }
}
