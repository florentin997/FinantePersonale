using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinantePersonale.Models
{
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

        public static int InsertValue(ValueModelCh value)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ValueModelCh>();
                return conn.Insert(value);
            }
        }
        
        //METODA DE STERS nu stiu daca merge 
        //public static async Task<bool> Delete(ValueModelCh cheltuiala)
        //{
          
        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {

        //        if (cheltuiala != null)
        //        {
        //            conn.Delete(cheltuiala);
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //}

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
