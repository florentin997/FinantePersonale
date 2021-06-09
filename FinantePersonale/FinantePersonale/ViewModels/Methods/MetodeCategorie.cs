using FinantePersonale.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinantePersonale.ViewModels.Methods
{
    class MetodeCategorie
    {

        public static int InsertValue(Categorie value)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Categorie>();          //tabelul e creat doar prima data, daca deja exista, nu mai e creat 
                return conn.Insert(value);
            }
        }

        //Functioneaza corect
        public static bool ExistaInregistrare(Categorie value)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                var testExista = conn.Query<Categorie>("SELECT Id,CategoriePrincipala, NumeSubcategorie FROM Categorie WHERE CategoriePrincipala='" + value.CategoriePrincipala + "' and NumeSubcategorie='" + value.NumeSubcategorie + "'").FirstOrDefault();

                var count = 0;
                if (testExista == null)
                {
                    count = 0;
                }
                else
                {
                    count = 1;
                }
                if (count == 0)
                {
                    return false;
                }
                else
                    return true;
            }
        }


        ////////////////Nu este implementata inca
        ///metoda ce returneaza o lista cu categoriile salvate in BD
        //public static List<string> CategoriiDeTipDat(string value) //parametrul pasat este subcategoria
        //{
        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        var categ = conn.Query<Categorie>("SELECT NumeSubcategorie where CategoriePrincipala='" + value + "'");
        //        //List<string> listaCategorii = new List<string>();
        //        //for(int i=0;i<categ.Count;i++)
        //        //{
        //        //    listaCategorii.Add();
        //        //}

        //        List<string> listaCategorii = categ.Select(c => c.NumeSubcategorie).ToList();
        //        return listaCategorii;
        //    }
        //}


        public static List<Categorie> GetValue()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Categorie>();
                return conn.Table<Categorie>().ToList();
            }
        }

        public static List<Categorie> GetValue(string numeCategoriePrincipala)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Categorie>();

                var listaCateg = conn.Query<Categorie>("SELECT * FROM Categorie WHERE CategoriePrincipala='" + numeCategoriePrincipala + "'").ToList();

                return listaCateg;
            }
        }
    }
}
