using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Mine.Models;
using Mine.Views;

namespace Mine.ViewModels
{
    /// <summary>
    /// Class to control Items
    /// </summary>
    public class ItemIndexViewModel : BaseViewModel
    {
        public ObservableCollection<ItemModel> DataSet { get; set; }
        public Command LoadItemsCommand { get; set; }

        /// <summary>
        /// Constructor to set up the local database and configure messaging center
        /// </summary>
        public ItemIndexViewModel()
        {
            Title = "Items";
            DataSet = new ObservableCollection<ItemModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ItemCreatePage, ItemModel>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as ItemModel;
                DataSet.Add(newItem);
                await DataStore.CreateAsync(newItem);
            });

            //Subscribe message for deletion
            MessagingCenter.Subscribe<ItemDeletePage, ItemModel>(this, "DeleteItem", async (obj, item) =>
            {
                var data = item as ItemModel;
                
                await DeleteAsync(data);
            });

            //Subscribe message for update
            MessagingCenter.Subscribe<ItemUpdatePage, ItemModel>(this, "UpdateItem", async (obj, item) =>
            {
                var data = item as ItemModel;

                await UpdateAsync(data);
            });
        }

        /// <summary>
        /// Read an item from the datastore
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ItemModel> ReadAsync(string id)
        {
            //return result into a variable, then return the result to make debugging easier
            var result = await DataStore.ReadAsync(id);

            return result;
        }

        /// <summary>
        /// Delete the record from the system
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(ItemModel item)
        {
            //Check if the item exist
            var record = await ReadAsync(item.Id);
            if(record == null)
            {
                return false;
            }

            //If item exist, remove the item from our local data store
            DataSet.Remove(item);

            //Call to remove it from the remote Data Store
            var result = await DataStore.DeleteAsync(item.Id);

            return result;
        }

        /// <summary>
        /// Update the record in the system
        /// </summary>
        /// <param name="item">The record to update</param>
        /// <returns>True if updated</returns>
        public async Task<bool> UpdateAsync(ItemModel item)
        {
            //Check if the item exist
            var record = await ReadAsync(item.Id);
            if (record == null)
            {
                return false;
            }

            //Call to update it in the remote Data Store
            var result = await DataStore.UpdateAsync(item);

            var canExecute = LoadItemsCommand.CanExecute(null);
            LoadItemsCommand.Execute(canExecute);

            return result;
        }

        /// <summary>
        /// Load the item from database to our local database
        /// </summary>
        /// <returns></returns>
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                DataSet.Clear();
                var items = await DataStore.IndexAsync(true);
                foreach (var item in items)
                {
                    DataSet.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}