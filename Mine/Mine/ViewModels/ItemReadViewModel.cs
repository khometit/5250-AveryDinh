using System;

using Mine.Models;

namespace Mine.ViewModels
{
    /// <summary>
    /// View Model for Item Read page
    /// </summary>
    public class ItemReadViewModel : BaseViewModel
    {
        public ItemModel Item { get; set; }

        /// <summary>
        /// Default constructor that takes an ItemModel, which defaults to null if nothing is passed
        /// </summary>
        /// <param name="item"></param>
        public ItemReadViewModel(ItemModel item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
