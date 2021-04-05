﻿
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinantePersonale.Models
{
    //[Table("WishlistItems")]
    public class ModelWishlist
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(25)]
        public string ItemName { get; set; }

        public float ItemValue { get; set; }

        //public float Procent { get; set; }

        public ModelWishlist()
        {

        }

        public static int InsertValue(ModelWishlist value)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                //conn.CreateTable<ModelWishlist>();
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

        public static ModelWishlist GetRowFromDB(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                return conn.Table<ModelWishlist>().FirstOrDefault(x=>x.Id==id);
                //return conn.Find<ModelWishlist>(Id);
            }
        }
    }
}
