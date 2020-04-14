using client.Api;
using client.Model;
using Newtonsoft.Json.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using client.Helpers;

namespace client.View.ProductListing
{
    /// <summary>
    /// Interaction logic for ProductListing.xaml
    /// </summary>
    public partial class ProductListing : UserControl
    {
        public ChangeRouteEvent ChangeRouteEvent { get; set; }

        private ProductFilter _filter;
        private readonly ProductAPI _productAPI;
        public List<Product> Products { get; set; }
        public ProductListing()
        {
            this.ChangeRouteEvent = new ChangeRouteEvent();
            InitializeComponent();
            this._productAPI = new ProductAPI();
            _filter = new ProductFilter();
            this.DataContext = this;
        }
        public ProductListing(ProductFilter filter)
        {
            this.ChangeRouteEvent = new ChangeRouteEvent();
            InitializeComponent();
            this._productAPI = new ProductAPI();
            _filter = filter;
            getProducts();
            this.DataContext = this;

        }
        private void getProducts()
        {
            if (_filter.ChildCategoryId != 0)
            {
                var data = _productAPI.GetProductsByChildCategoryId(_filter.ChildCategoryId);
                var list = new List<Product>();
                var arr = ((JArray)data.Data).Children();
                foreach (var i in arr)
                {
                    var item = i.ToObject<Product>();
                    list.Add(item);
                }
                this.Products = list;
            }
        }
    }
}
