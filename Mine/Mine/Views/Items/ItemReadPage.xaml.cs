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
    public partial class ItemReadPage : ContentPage
    {
        ItemReadViewModel viewModel;

        /// <summary>
        /// Constructor that takes an ItemReadViewModel
        /// </summary>
        /// <param name="viewModel"></param>
        public ItemReadPage(ItemReadViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }


        /// <summary>
        /// Constructor that takes no argument.
        /// </summary>
        public ItemReadPage()
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
        /// Open the delete page for this iem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            //pushing a delete page on the modal stack, using the constructor that takes ItemReadViewModel
            //view model then gets used for data binding
            await Navigation.PushModalAsync(new NavigationPage(new ItemDeletePage(viewModel)));

            await Navigation.PopAsync();
        }

        /// <summary>
        /// Open the Update page when Update button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void UpdateItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemUpdatePage(viewModel)));

            await Navigation.PopAsync();
        }
    }
}