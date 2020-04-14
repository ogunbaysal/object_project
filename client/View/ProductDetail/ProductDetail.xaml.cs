using System;
using System.Collections.Generic;
using System.Linq;
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
using client.Api;
using client.Helpers;
using client.Model;
using Newtonsoft.Json.Linq;

namespace client.View.ProductDetail
{
    /// <summary>
    /// Interaction logic for ProductDetail.xaml
    /// </summary>
    public partial class ProductDetail : UserControl
    {

        public static readonly DependencyProperty ProductIdProperty = DependencyProperty.Register("ProductId", typeof(long), typeof(ProductDetail), new FrameworkPropertyMetadata(null));
        public long ProductId
        {
            get { return long.Parse(GetValue(ProductIdProperty).ToString()); }
            set { SetValue(ProductIdProperty, value); }
        }

        public Product Product { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public string SelectedProductImageUrl { get; set; }

        public List<ProductProperty> ProductProperties { get; set; }

        public ProductProperty Selected { get; set; }

        public List<ProductColor> AvailableColors { get; set; }
        public List<ProductSize> AvailableSizes { get; set; }


        private ProductAPI _productApi;
        private ProductPropertyAPI _productPropertyApi;
        public ProductDetail()
        {

            InitializeComponent();
        }

        public ProductDetail(long ProductId)
        {
            this.ProductId = ProductId;
            InitializeComponent();
            Loaded += ProductDetail_Loaded;
        }

        private void getProductDetailProperties(long id)
        {
            this.Selected = GetProperty(id);
            setProductImages();

        }
        private void ProductDetail_Loaded(object sender, RoutedEventArgs e)
        {
            _productApi = new ProductAPI();
            _productPropertyApi = new ProductPropertyAPI();;
            Product = getProduct(ProductId);
            ProductProperties = getProductProperties(ProductId);
            Selected = FindCheaperProperty();
            setProductImages();
            setAvailableProducts();
            setBodySizes();
            this.DataContext = this;
        }

        private void setAvailableProducts()
        {
            if (this.ProductProperties == null) throw new Exception("No Product Property");
            var list = new List<long>();
            foreach (var item in this.ProductProperties)
            {
                if(item.ProductColorId == null) continue;
                if(list.Contains((long) item.ProductColorId)) continue;
                list.Add((long)item.ProductColorId);
            }

            var colors = new List<ProductColor>();
            foreach (var item in list)
            {
                var result = _productPropertyApi.GetColor(item);
                colors.Add(JObjectToObject.Convert<ProductColor>(result.Data));
            }

            this.AvailableColors = colors;
        }

        private void setBodySizes()
        {
            if (this.ProductProperties == null) throw new Exception("No Product Property");
            var list = new List<long>();
            foreach (var item in this.ProductProperties)
            {
                if (item.ProductSizeId == null) continue;
                if (list.Contains((long)item.ProductSizeId)) continue;
                list.Add((long)item.ProductSizeId);
            }

            var sizes = new List<ProductSize>();
            foreach (var item in list)
            {
                var result = _productPropertyApi.GetSize(item);
                sizes.Add(JObjectToObject.Convert<ProductSize>(result.Data));
            }

            this.AvailableSizes = sizes;
        }

        private Product getProduct(long Id)
        {
            var data = _productApi.GetOne(Id);
            var item = ((JObject)data.Data).ToObject<Product>();
            return item;
        }

        private List<ProductProperty> getProductProperties(long productId)
        {
            var data = _productApi.GetProperties(productId);
            var list = JArrayToList.Convert<ProductProperty>(data.Data);
            return list;
        }

        private ProductProperty FindCheaperProperty()
        {
            if (this.ProductProperties == null) throw new Exception("No Property Found");
            var list = new List<ProductProperty>(this.ProductProperties);
            list.Sort((x, y) => x.Price.CompareTo(y.Price));
            return list[0];
        }

        private ProductProperty GetProperty(long id)
        {
            if (this.ProductProperties == null) throw new Exception("No Property Found");
            var item = this.ProductProperties.FirstOrDefault(x => x.ProductPropertyId == id);
            if (item != null) return item;
            throw new Exception("Property#"+id+" not found");
        }
        private void setProductImages()
        {
            if (Selected == null)
                throw new Exception("No Property Property");
            var data = _productApi.GetPropertyImages(Selected.ProductPropertyId);
            this.ProductImages = JArrayToList.Convert<ProductImage>(data.Data);
            this.SelectedProductImageUrl = ProductImages[0].Url;
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {

        }


        private void onPropertyButtonClicked(object sender, MouseButtonEventArgs e)
        {
            var clicked = (Button)sender;
            if (clicked.Tag != null) return;
            var id = (long)clicked.Tag;
            getProductDetailProperties(id);
        }

        private void onPropertyImageClicked(object sender, MouseButtonEventArgs e)
        {
            var clicked = (Image)sender;
            if (clicked.Tag != null) return;
            var id = (long)clicked.Tag;
            getProductDetailProperties(id);
        }
    }
}
