using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinantePersonale.Models
{
    public class ValueModelVen
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Subcategorie { get; set; }

        public decimal Suma { get; set; }

        public DateTime Date { get; set; }

        public ValueModelVen()
        {

        }
        
        public static int InsertValue(ValueModelVen value)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ValueModelVen>();
                return conn.Insert(value);
            }
        }

        public static List<ValueModelVen> GetValue()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ValueModelVen>();
                return conn.Table<ValueModelVen>().ToList();
            }
        }
    }
}
