﻿using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThoughtRecordApp.DAL.Models
{
    public class Situation
    {
        [PrimaryKey, AutoIncrement]
        public int SituationId { get; set; }

        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        [ForeignKey(typeof(ThoughtRecord))]
        public int ThoughtRecordId { get; set; }

        [OneToOne]
        public ThoughtRecord ThoughtRecord { get; set; }
    }
}
