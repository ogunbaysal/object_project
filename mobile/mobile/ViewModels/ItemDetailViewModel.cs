using System;

using mobile.Models;

namespace mobile.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Item = item;
        }
    }
}
