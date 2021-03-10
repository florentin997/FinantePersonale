
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinantePersonale.Models
{
    public class ModelWishlist
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(25)]
        public string Item { get; set; }

        public float ItemValue { get; set; }

        public float Procent { get; set; }

        public ModelWishlist()
        {

        }

        public static int InsertValue(ModelWishlist value)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ModelWishlist>();
                return conn.Insert(value);
            }
        }

        public static List<ModelWishlist> GetValue()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ModelWishlist>();
                return conn.Table<ModelWishlist>().ToList();
            }
        }
    }
}
