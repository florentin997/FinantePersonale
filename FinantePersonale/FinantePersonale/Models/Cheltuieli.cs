using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinantePersonale.Models
{
    public class Cheltuieli
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Subcategorie { get; set; }

        public decimal Suma { get; set; }

        public DateTime Date { get; set; }

        public Cheltuieli()
        {

        }

        public static int InsertCheltuieli(Cheltuieli cheltuieli)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Cheltuieli>();
                return conn.Insert(cheltuieli);
            }
        }

        public static List<Cheltuieli> GetExpenses()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Cheltuieli>();
                return conn.Table<Cheltuieli>().ToList();
            }
        }
    }
}
