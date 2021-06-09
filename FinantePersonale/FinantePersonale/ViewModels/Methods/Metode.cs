using FinantePersonale.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinantePersonale.ViewModels.Methods
{
    class Metode
    {

        //public static bool VerificareDacaBGEsteGoala()
        //{
        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        int z = 0;
        //        var testBD = conn.Query<Categorie>("SELECT count(*) from Categorie WHERE Id!=" + z + "'");
        //        int count = testBD.Count();

        //        if (count > 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //}



        //diferenta dintre VENITURI si CHELTUIELI pe luna selectat din UI
        //TREBUIE IMPLEMENTAT
        //public static string DiferentaChVen(string luna)//CA PARAMETRU PASEZ NUMARUL LUNII PE CARE IL SELECTEAZA USERUL DIN UI
        //{ 

        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        var listaPeLunaCh = conn.Query<float>("SELECT SUM(SumaCh) FROM ValueModelCh WHERE DateCh=(SELECT strftime('%M'='" + luna+"','now'))").ToString();
        //        //luna trebuie sa fie in format "01"..."12" etc   
        //        //lista cu stringuri si dupa fac cast la (float) cand folosesc valorile ????
        //        var listaPeLunaVen = conn.Query<float>("SELECT SUM(SumaVen) FROM ValueModelVen WHERE DateVen=(SELECT strftime('%M'='" + luna + "','now'))").ToString();

        //        var difDintreSume = float.Parse(listaPeLunaVen) - float.Parse(listaPeLunaCh);

        //        return difDintreSume.ToString();
        //    }
        //}
        public static string DiferentaCV()
        {

            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                //varianta 1
                //var sumaCh = conn.Query<ValueModelCh>("SELECT SumaCh FROM ValueModelCh").FirstOrDefault();  
                //var sumaVen = conn.Query<ValueModelVen>("SELECT SumaVen FROM ValueModelVen").FirstOrDefault();
                //var difDintreSume = sumaVen.SumaVen - sumaCh.SumaCh;
                //return difDintreSume.ToString();

                //varianta 2
                //var sumaCh1 = conn.Query<float>("SELECT SUM(SumaCh) FROM ValueModelCh");
                //var sumaVen1 = conn.Query<float>("SELECT SUM(SumaVen) FROM ValueModelVen");
                //float SV = sumaVen1.Sum();
                //float SC = sumaCh1.Sum();
                //float dif = SV - SC;
                //return dif.ToString();

                //Varianta 3 
                var listValVen = conn.Query<ValueModelVen>("SELECT * FROM ValueModelVen");
                List<float> propV = listValVen.Select(o=>o.SumaVen).ToList();
                var listValCh = conn.Query<ValueModelCh>("SELECT * FROM ValueModelCh");
                List<float> propC = listValCh.Select(o => o.SumaCh).ToList();

                

                var suma = propV.Sum()-propC.Sum();

                if (listValVen == null && listValCh == null)
                {
                    return suma.ToString("0");
                }
                else
                return suma.ToString();

            }
        }


    }
}
