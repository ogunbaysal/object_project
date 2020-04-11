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

namespace client.Components.ProductListing
{
    
    /// <summary>
    /// Interaction logic for ProductListingItem.xaml
    /// </summary>
    public partial class ProductListingItem : UserControl
    {
        public static readonly DependencyProperty ProductIdProperty = DependencyProperty.Register("ProductId", typeof(long), typeof(UserControl), new FrameworkPropertyMetadata(null));
        public long ProductId
        {
            get { return long.Parse(GetValue(ProductIdProperty).ToString()); }
            set { SetValue(ProductIdProperty, value); }
        }
        public Product Product { get; set; }
        public List<ProductImage> ProductImages { get; set; }

        public String Price { get; set; }

        private ProductAPI _productAPI;
        private ProductProperty cheaperProductProperty;
        public ProductListingItem()
        {
            InitializeComponent();
            Loaded += ProductListingItem_Loaded;
        }

        private void ProductListingItem_Loaded(object sender, RoutedEventArgs e)
        {
            _productAPI = new ProductAPI();
            this.initialize();
        }

        private void initialize()
        {
            Product = getProduct(ProductId);
            cheaperProductProperty = this.getCheaperProductProperty(ProductId);
            ProductImages = getImages();

            this.Price = getPrice(ProductId);
            this.DataContext = this;
        }
        private List<ProductImage> getImages()
        {
            if (cheaperProductProperty == null)
                throw new Exception("No Product Property");
            var data = _productAPI.GetPropertyImages(cheaperProductProperty.ProductPropertyId);
            var list = new List<ProductImage>();
            var arr = ((JArray)data.Data).Children();
            foreach (var i in arr)
            {
                var item = i.ToObject<ProductImage>();
                list.Add(item);
            }
            return list;
        }
        private Product getProduct(long Id)
        {
            var data = _productAPI.GetOne(Id);
            var item = ((JObject)data.Data).ToObject<Product>();
            return item;
        }
        private ProductProperty getCheaperProductProperty(long productId)
        {
            var data = _productAPI.GetProperties(productId);
            var list = new List<ProductProperty>();
            var arr = ((JArray)data.Data).Children();
            foreach (var i in arr)
            {
                var item = i.ToObject<ProductProperty>();
                list.Add(item);
            }
            list.Sort((x, y) => x.Price.CompareTo(y.Price));
            return list[0];
        }
        private String getPrice(long productId)
        {
            if (cheaperProductProperty == null)
                cheaperProductProperty = getCheaperProductProperty(productId);
            return cheaperProductProperty.Price.ToString() + " TL";
        }
    }
}
