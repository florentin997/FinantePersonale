using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinantePersonale.Models
{
    [Table("ValueModelVen")]
    public class ValueModelVen
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string SubcategorieVen { get; set; }

        public float SumaVen { get; set; }

        public DateTime DateVen { get; set; }

        public ValueModelVen()
        {

        }



        //ptr SF chart
        public ValueModelVen(string xValue, float yValue)
        {
            SubcategorieVen = xValue;
            SumaVen = yValue;
        }
        //---------
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
    }
}
