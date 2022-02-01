using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    /// <summary>
    /// Fake datastore
    /// </summary>
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        /// <summary>
        /// Default constructor, create some test data
        /// </summary>
        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Cottage Ball", Description="Hit you with softness.", Value=7 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Holy light", Description="Bright and holy like your future.", Value=10 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Electric kettle", Description="Spice up your morning with some hot tea.", Value=5 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Destroyer's comb", Description="Coming at your hair to make them extra pretty.", Value=3 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Keyboard", Description="Help you express yourself digitally.", Value=4 },
            };
        }

        /// <summary>
        /// Create a new item in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Update an item in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Delete an item from the databse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Retrieve an item from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }


        /// <summary>
        /// Return all records in the database
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ItemModel>> IndexAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}