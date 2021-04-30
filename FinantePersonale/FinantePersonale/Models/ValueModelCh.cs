using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinantePersonale.Models
{
    //[Table("ValueModelCh")]
    public class ValueModelCh
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int IdCh { get; set; }

        public string SubcategorieCh { get; set; }

        public float SumaCh { get; set; }

        public DateTime DateCh { get; set; }

        public ValueModelCh()
        {

        }

        //---------------legat de graficul syncfusion
        public ValueModelCh(string xValue, float yValue)
        {
            SubcategorieCh = xValue;
            SumaCh = yValue;
        }
        //---------------pana aici

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

        public static ValueModelCh GetRowFromDB(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                return conn.Table<ValueModelCh>().FirstOrDefault(x => x.IdCh == id);
            }
        }
    }
}
