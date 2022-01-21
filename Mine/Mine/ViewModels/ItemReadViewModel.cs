using System;

using Mine.Models;

namespace Mine.ViewModels
{
    public class ItemReadViewModel : BaseViewModel
    {
        public ItemModel Item { get; set; }
        public ItemReadViewModel(ItemModel item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
