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
        public static bool ExistaInregistrareCh(ValueModelCh value)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                var testExista = conn.Query<ValueModelCh>("SELECT IdCh FROM ValueModelCh WHERE SubcategorieCh=' " + value.SubcategorieCh+" ' ").FirstOrDefault();

                var count = 0;
                if (testExista is null)
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

        public static ValueModelCh UpdateCh(ValueModelCh value)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {

                var idRand = conn.Query<ValueModelCh>("SELECT IdCh FROM ValueModelCh WHERE SubcategorieCh='" + value.SubcategorieCh + "'").FirstOrDefault();
                var sumRand = conn.Query<ValueModelCh>("SELECT SumaCh FROM ValueModelCh WHERE SubcategorieCh='" + value.SubcategorieCh + "'").FirstOrDefault();

                ValueModelCh obiectDeUpdatat = conn.Query<ValueModelCh>("UPDATE ValueModelCh SET SumaCh=(SELECT SUM(" + value.SumaCh + "," + sumRand + ") WHERE IdCh=" + idRand.IdCh).FirstOrDefault();
                //SQLite.SQLiteException: 'incomplete input'------------------------------------------------------------!!!!!!!!!!!!!!
                return obiectDeUpdatat;
            }
        }

        //diferenta dintre VENITURI si CHELTUIELI pe luna selectat din UI
        public static string DiferentaChVen(string luna)//CA PARAMETRU PASEZ NUMARUL LUNII PE CARE IL SELECTEAZA USERUL DIN UI
        { 

            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                var listaPeLunaCh = conn.Query<float>("SELECT SUM(SumaCh) FROM ValueModelCh WHERE DateCh=(SELECT strftime('%M'='" + luna+"','now'))").ToString();
                //luna trebuie sa fie in format "01"..."12" etc   
                //lista cu stringuri si dupa fac cast la (float) cand folosesc valorile ????
                var listaPeLunaVen = conn.Query<float>("SELECT SUM(SumaVen) FROM ValueModelVen WHERE DateVen=(SELECT strftime('%M'='" + luna + "','now'))").ToString();

                var difDintreSume = float.Parse(listaPeLunaVen) - float.Parse(listaPeLunaCh);

                return difDintreSume.ToString();
            }
        }
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
                return suma.ToString();

            }
        }
        public static string TotalCh()  // sum imi da 0, cred ca gresesc la queri
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                var records = conn.Query<ValueModelCh>("SELECT * FROM ValueModelCh");
                float sum=0; 
                foreach(var r in records)
                {
                    sum = sum + r.SumaCh;
                }
                return sum.ToString();
            }
        }
        public static float TotalVen()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                var sum = conn.Query<float>("SELECT SUM(SumaVen) FROM ValueModelVen").FirstOrDefault();

                return sum;
            }
        }

    }
}
