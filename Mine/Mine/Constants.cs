using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mine
{
    /// <summary>
    /// Class containing data used to database connection
    /// </summary>
    public static class Constants
    {
        //public const string DatabaseFilename = "TodoSQLite.db3";
        public const string DatabaseFilename = "mine.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the databse in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            //create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            //enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        //Construct the path that will be used for connection.
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
