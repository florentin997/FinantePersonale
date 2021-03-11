using System;
using System.Collections.Generic;
using System.Text;
using FinantePersonale.Models;
using SQLite;

namespace FinantePersonale.Models
{
    class ElementeDinDB
    {

        public ElementeDinDB()
        {

        }

        private int sumaVen;

        public int SumaVen
        {
            get { return sumaVen; }
            set { sumaVen = value; }
        }

        public static List<ValueModelCh> GetValue()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ValueModelCh>();
                return conn.Table<ValueModelCh>().ToList();
            }
        }


        public List<ValueModelVen> GetListaVenituriFromDB()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ValueModelVen>();
                return conn.Table<ValueModelVen>().ToList();
            }
        }

        private int sumaVenituriDinBD;

        public int SumaVenituriDinBD
        {
            get { return sumaVenituriDinBD; }
            set { sumaVenituriDinBD = value; }
        }


    }
}
