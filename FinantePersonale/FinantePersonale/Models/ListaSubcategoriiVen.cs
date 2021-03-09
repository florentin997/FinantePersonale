using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinantePersonale.Models
{
    class ListaSubcategoriiVen
    {

        /// <summary>
        /// ACEASTA ESTE TABELA CE VA CONTINE TOATE SUBCATEGORIILE PENTRU VENITURI,
        /// ATAT CELE PREDEFINITE CAT SI CELE ADAUGATE DE UTILIZATOR
        /// </summary>

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25)]
        public string SubcategorieCh { get; set; }

        public static int InsertValue(ListaSubcategoriiVen value)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ListaSubcategoriiVen>();
                return conn.Insert(value);
            }
        }

        public static List<ListaSubcategoriiVen> GetValue()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ListaSubcategoriiVen>();
                return conn.Table<ListaSubcategoriiVen>().ToList();
            }
        }
    }
}
