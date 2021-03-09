using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinantePersonale.Models
{
    class ListaSubcategoriiCh
    {
        /// <summary>
        /// ACEASTA ESTE TABELA CE VA CONTINE TOATE SUBCATEGORIILE PENTRU CHELTUIELI,
        /// ATAT CELE PREDEFINITE CAT SI CELE ADAUGATE DE UTILIZATOR
        /// </summary>

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25)]
        public string SubcategorieCh { get; set; }

        public static int InsertValue(ListaSubcategoriiCh value)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ListaSubcategoriiCh>();
                return conn.Insert(value);
            }
        }

        public static List<ListaSubcategoriiCh> GetValue()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ListaSubcategoriiCh>();
                return conn.Table<ListaSubcategoriiCh>().ToList();
            }
        }
    }
}
