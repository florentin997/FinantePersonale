using FinantePersonale.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinantePersonale.ViewModels.Methods
{
    class MetodeCh
    {
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

        public static List<ValueModelCh> GetValue(string subcategorie)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ValueModelCh>();
                return conn.Table<ValueModelCh>().Where(e => e.SubcategorieCh == subcategorie).ToList();
            }
        }

        /////////nu este implementata
        //public static ValueModelCh GetRowFromDB(int id)
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        return conn.Table<ValueModelCh>().FirstOrDefault(x => x.IdCh == id);
        //    }
        //}



        // in cazul in care fac un tabel in care sa am valoarea totala a Ch
        //public static string TotalCh()  // sum imi da 0, cred ca gresesc la queri
        //{
        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        var records = conn.Query<ValueModelCh>("SELECT * FROM ValueModelCh");
        //        float sum = 0;
        //        foreach (var r in records)
        //        {
        //            sum = sum + r.SumaCh;
        //        }
        //        return sum.ToString();
        //    }
        //}


        //public static ValueModelCh UpdateCh(ValueModelCh value)
        //{
        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {

        //        var idRand = conn.Query<ValueModelCh>("SELECT IdCh FROM ValueModelCh WHERE SubcategorieCh='" + value.SubcategorieCh + "'").FirstOrDefault();
        //        var sumRand = conn.Query<ValueModelCh>("SELECT SumaCh FROM ValueModelCh WHERE SubcategorieCh='" + value.SubcategorieCh + "'").FirstOrDefault();

        //        ValueModelCh obiectDeUpdatat = conn.Query<ValueModelCh>("UPDATE ValueModelCh SET SumaCh=(SELECT SUM(" + value.SumaCh + "," + sumRand + ") WHERE IdCh=" + idRand.IdCh).FirstOrDefault();
        //        //SQLite.SQLiteException: 'incomplete input'------------------------------------------------------------!!!!!!!!!!!!!!
        //        return obiectDeUpdatat;
        //    }
        //}
    }
}
