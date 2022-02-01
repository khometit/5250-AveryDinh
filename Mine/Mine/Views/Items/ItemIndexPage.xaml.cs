using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Mine.Models;
using Mine.Views;
using Mine.ViewModels;

namespace Mine.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemIndexPage : ContentPage
    {
        ItemIndexViewModel viewModel;

        /// <summary>
        /// default constructor takes no argument
        /// </summary>
        public ItemIndexPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemIndexViewModel();
        }

        /// <summary>
        /// Event handler for when an item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ItemModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemReadPage(new ItemReadViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        /// <summary>
        /// Event handler for when Add button is clicked, redirect to Create page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemCreatePage()));
        }

        /// <summary>
        /// Instructs what the page should do upon appearing
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.DataSet.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}