using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinantePersonale.Models
{
    public class Categorie
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string CategoriePrincipala { get; set; } //daca e venit sau cheltuiala
        [MaxLength(20)]
        public string NumeSubcategorie { get; set; }   //denumriea categoriei 


        public Categorie()
        {

        }

        public static int InsertValue(Categorie value)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Categorie>();
                return conn.Insert(value);
            }
        }

        public static List<Categorie> GetValue()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Categorie>();
                return conn.Table<Categorie>().ToList();
            }
        }

    }
}
