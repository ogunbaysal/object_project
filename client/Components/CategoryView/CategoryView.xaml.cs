using client.Api;
using client.Api.Models;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace client.Components.CategoryView
{
    /// <summary>
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl
    {
        private RestClient client;
        private List<SubCategory> SubCategories;
        private long  MainCategoryId { get; set; }
        public CategoryView(long mainCategoryId)
        {
            MainCategoryId = mainCategoryId;
            this.client = API.getInstance().Client;
            InitializeComponent();
            this.getSubCategories();
        }
        private async void getSubCategories()
        {
            var request = new RestRequest("category/subs/{id}", RestSharp.DataFormat.Json).AddParameter("id", this.MainCategoryId, ParameterType.UrlSegment);
            var categories = await client.GetAsync<List<SubCategory>>(request);
            this.SubCategories = categories;
            
        }
    }
}
