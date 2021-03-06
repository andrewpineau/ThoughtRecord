﻿using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThoughtRecordApp.DAL.Concrete
{
    /// <summary>
    /// Creates a connection object which can be used by DatabaseService and 
    /// Repository instances.
    /// </summary>
    public class ConnectionManager
    {
        public static readonly string FileName = "db.sqlite";

        private static string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(new SQLitePlatformWinRT(), path);
        }
        public static SQLiteAsyncConnection GetAsyncConnection()
        {
            var connString = new SQLiteConnectionString(path, storeDateTimeAsTicks: true);
            var connWithLock = new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), connString);
            return new SQLiteAsyncConnection(() => connWithLock);
        }
    }
}
