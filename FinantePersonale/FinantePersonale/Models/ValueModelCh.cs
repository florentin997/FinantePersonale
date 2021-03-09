using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinantePersonale.Models
{
    public class ValueModelCh
    {
        [PrimaryKey, AutoIncrement]
        public int IdCh { get; set; }

        public string SubcategorieCh { get; set; }

        public float SumaCh { get; set; }

        public DateTime DateCh { get; set; }

        public ValueModelCh()
        {

        }

        public static int InsertValue(ValueModelCh value)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ValueModelCh>();
                return conn.Insert(value);
            }
        }

        public static List<ValueModelCh> GetValue()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ValueModelCh>();
                return conn.Table<ValueModelCh>().ToList();
            }
        }
    }
}
