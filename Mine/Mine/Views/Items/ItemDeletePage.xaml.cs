using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mine.Models;
using Mine.ViewModels;

namespace Mine.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDeletePage : ContentPage
    {
        ItemReadViewModel viewModel;

        public ItemDeletePage(ItemReadViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDeletePage()
        {
            InitializeComponent();

            var item = new ItemModel
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemReadViewModel(item);
            BindingContext = viewModel;
        }


        /// <summary>
        /// Cancel the deletion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void CancelItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Delete the selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            //Call the MessageCenter to let it know that we wanna delete an item
            MessagingCenter.Send(this, "DeleteItem", viewModel.Item);

            await Navigation.PopModalAsync();
        }
    }
}