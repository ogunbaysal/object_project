using mobile.DataServices.Interface;
using mobile.Models;
using mobile.Services;
using mobile.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private ICategoryService _service;

        public List<HomeMenuItem> Categories { get; set; }

        public HomeViewModel(ICategoryService service)
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
