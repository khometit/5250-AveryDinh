using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mine.Services
{
    /// <summary>
    /// Interface for interactions with the data store
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataStore<T>
    {
        /// <summary>
        /// Create a new record
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(T item);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T item);

        /// <summary>
        /// Delete a record from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(string id);

        /// <summary>
        /// Retrieve a record from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> ReadAsync(string id);

        /// <summary>
        /// Retrieve all available records
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> IndexAsync(bool forceRefresh = false);
    }
}
