using mobile.DataServices.Interface;
using mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.ViewModels.Component
{
    public class FlyoutHeaderViewModel : BaseViewModel
    {
        public List<HomeMenuItem> Categories { get; set; }
        private ICategoryService _service;
        public FlyoutHeaderViewModel(ICategoryService service)
        {
            _service = service;
            getCategories();
        }
        private void getCategories()
        {
            Categories = new List<HomeMenuItem>();
            var categories = _service.getCategories();
            foreach (var item in categories)
            {
                Categories.Add(new HomeMenuItem()
                {
                    Title = item.Title,
                    Id = item.CategoryId
                });
            }
        }

    }
}
