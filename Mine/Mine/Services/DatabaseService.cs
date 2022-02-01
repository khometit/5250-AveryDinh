using System;
using System.Linq;
using System.Threading.Tasks;

using SQLite;
using Mine.Models;
using System.Collections.Generic;

namespace Mine.Services
{
    /// <summary>
    /// Class to set up our service to the database
    /// </summary>
    public class DatabaseService : IDataStore<ItemModel>
    {
        //initializer
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        //Set up the databse connection
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        /// <summary>
        /// Constructure to fire up the database service
        /// </summary>
        public DatabaseService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        /// <summary>
        /// Check if the database has been initialized. If not, initialize by creating tables.
        /// </summary>
        /// <returns></returns>
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ItemModel)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        /// <summary>
        /// Create a new item in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(ItemModel item)
        {
            //Can't create an empty item
            if(item == null)
            {
                return false;
            }

            //if item successfully added, the # of rows added to the item must be > 0
            var result = await Database.InsertAsync(item);
            if(result == 0)
            {
                return false;
            }

            return true;


        }

        /// <summary>
        /// Update an item in the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(ItemModel item)
        {
            //return if id is invalid
            if (item == null)
            {
                return false;
            }

            //Otherise, update the item in our database
            //result of rows updated should be > 0
            var result = await Database.UpdateAsync(item);
            if(result == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Delete an item from the databse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string id)
        {
            //Retrieve a copy from the database to make sure there exists one
            var data = await ReadAsync(id);
            if(data == null)
            {
                return false;
            }

            //remove the item from our database
            var result = await Database.DeleteAsync(data);
            //# of rows deleted should be > 0
            if(result == 0)
            {
                return false;
            }

            return true;
            
        }

        /// <summary>
        /// Retrieve an item from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ItemModel> ReadAsync(string id)
        {
            //return if id is invalid
            if(id == null)
            {
                return null;
            }

            //Otherise, look up in our database
            //Using Linq syntax to find the first record that has the ID that matches
            var result = Database.Table<ItemModel>().FirstOrDefaultAsync(m => m.Id.Equals(id));
            return result;
        }

        /// <summary>
        /// Return all records in the database
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ItemModel>> IndexAsync(bool forceRefresh = false)
        {
            //Retrieve the records
            var result = await Database.Table<ItemModel>().ToListAsync();

            //Return the result
            return result;
        }
    }
}
