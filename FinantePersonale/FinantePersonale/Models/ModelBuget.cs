using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinantePersonale.Models
{
    class ModelBuget
    {
        public string BugetZi { get; set; }
        public string BugetSaptamana { get; set; }
        public string BugetLuna { get; set; }
        public string BugetAn { get; set; }
        public string AlertaBuget { get; set; }

        //public static int InsertValue(ModelBuget value)
        //{
        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        conn.CreateTable<ModelBuget>();
        //        return conn.Insert(value);
        //    }
        //}

        //public static List<ModelBuget> GetValue()
        //{
        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        conn.CreateTable<ModelBuget>();
        //        return conn.Table<ModelBuget>().ToList();
        //    }
        //}
    }
}
