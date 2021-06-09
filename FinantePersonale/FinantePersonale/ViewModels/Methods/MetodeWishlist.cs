using FinantePersonale.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinantePersonale.ViewModels.Methods
{
    class MetodeWishlist
    {
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
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ModelWishlist>();
                return conn.Table<ModelWishlist>().ToList();
            }
        }

        //public static ModelWishlist GetRowFromDB(int id)
        //{
        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        return conn.Table<ModelWishlist>().FirstOrDefault(x => x.Id == id);
        //        //return conn.Find<ModelWishlist>(Id);
        //    }
        //}

        //public static  List<ModelWishlist> Read()
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        var posts = ModelWishlist.GetValue();// Where(p => p.UserId == App.user.Id).ToListAsync();
        //        return posts;
        //    }
        //}
    }
}
