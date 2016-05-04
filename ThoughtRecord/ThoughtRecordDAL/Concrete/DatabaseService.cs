﻿using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThoughtRecordApp.DAL.Abstract;
using ThoughtRecordApp.DAL.Models;
using Windows.Storage;

namespace ThoughtRecordApp.DAL.Concrete
{
    public class DatabaseService : IDatabaseService
    {
        private SQLiteAsyncConnection asyncConn;
        private IRepository<ThoughtRecord> thoughtRecords;
        private IRepository<Situation> situations;
        private IRepository<Emotion> emotions;
        private IRepository<Configuration> settings;

        public DatabaseService()
        {
            asyncConn = ConnectionManager.GetAsyncConnection();
            //Create all tables if they don't exist
            asyncConn.CreateTableAsync<ThoughtRecord>();
            asyncConn.CreateTableAsync<Situation>();
            asyncConn.CreateTableAsync<Emotion>();
                //conn.CreateTable<Configuration>();
        }

        private async Task<bool> DatabaseExists()
        {
            var dbFile = await ApplicationData.Current.LocalFolder.GetFileAsync(ConnectionManager.FileName);

            return dbFile != null;
        }

        public IRepository<ThoughtRecord> ThoughtRecords
        {
            get
            {
                if (thoughtRecords == null)
                {
                    thoughtRecords = new Repository<ThoughtRecord>(asyncConn);
                }
                return thoughtRecords;
            }
        }
        public IRepository<Situation> Situations
        {
            get
            {
                if (situations == null)
                {
                    situations = new Repository<Situation>(asyncConn);
                }
                return situations;
            }
        }

        public IRepository<Emotion> Emotions
        {
            get
            {
                if (emotions == null)
                {
                    emotions = new Repository<Emotion>(asyncConn);
                }
                return emotions;
            }
        }

        public IRepository<Configuration> Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = new Repository<Configuration>(asyncConn);
                }
                return settings;
            }
        }
    }
}
