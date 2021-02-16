using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinantePersonale.Models
{
    public class ValueModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Subcategorie { get; set; }

        public decimal Suma { get; set; }

        public DateTime Date { get; set; }

        public ValueModel()
        {

        }
        
        public static int InsertValue(ValueModel cheltuieli)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ValueModel>();
                return conn.Insert(cheltuieli);
            }
        }

        public static List<ValueModel> GetValue()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ValueModel>();
                return conn.Table<ValueModel>().ToList();
            }
        }
    }
}
