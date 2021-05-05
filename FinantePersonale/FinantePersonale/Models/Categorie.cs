using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinantePersonale.Models
{
    public class Categorie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(10)]
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
                conn.CreateTable<Categorie>();          //tabelul e creat doar prima data, daca deja exista, nu mai e creat 
                return conn.Insert(value);
            }
        }

        //public static bool ExistaInregistrare(Categorie value)
        //{
        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        SQLiteCommand cmd = new SQLiteCommand(conn);
        //        var test = conn.Query<Categorie>("SELECT count(*)  FROM Categorie WHERE CategoriePrincipala='" + value.CategoriePrincipala + "' and NumeSubcategorie='" + value.NumeSubcategorie + "'").FirstOrDefault();
        //        //Categorie z = new Categorie { CategoriePrincipala = "0", NumeSubcategorie = "0" };
        //        int count;
        //        if (test.CategoriePrincipala==null && test.NumeSubcategorie==null)  
        //        {
        //            count = 0;
        //        }
        //        else
        //        {
        //            count = 1;
        //        }
        //        if (count == 1) 
        //        {
        //            return false;
        //        }
        //        else
        //        return true;
        //    }
        //}

        //public static bool VerificareDacaBGEsteGoala()
        //{
        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        int z = 0;
        //        var testBD = conn.Query<Categorie>("SELECT count(*) from Categorie WHERE Id!="+z+"'");
        //        int count = testBD.Count();

        //        if (count > 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //}



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

        public static List<string> CategoriiDeTipDat(string value) //parametrul pasat este subcategoria
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                var categ = conn.Query<Categorie>("SELECT NumeSubcategorie where CategoriePrincipala='"+value+"'");
                //List<string> listaCategorii = new List<string>();
                //for(int i=0;i<categ.Count;i++)
                //{
                //    listaCategorii.Add();
                //}

                List<string> listaCategorii = categ.Select(c=>c.NumeSubcategorie).ToList();
                return listaCategorii;
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
