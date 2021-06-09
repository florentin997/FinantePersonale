using FinantePersonale.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinantePersonale.ViewModels.Methods
{
    class MetodeVen
    {
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
        public static List<ValueModelVen> GetValue(string subcategorie)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ValueModelVen>();
                return conn.Table<ValueModelVen>().Where(e => e.SubcategorieVen == subcategorie).ToList();
            }
        }

        //public static float TotalVen()
        //{
        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        var sum = conn.Query<float>("SELECT SUM(SumaVen) FROM ValueModelVen").FirstOrDefault();

        //        return sum;
        //    }
        //}

    }
}
