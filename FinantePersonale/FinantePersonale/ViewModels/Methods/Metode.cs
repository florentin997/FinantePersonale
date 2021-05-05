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

                var idRand= conn.Query<ValueModelCh>("SELECT IdCh FROM ValueModelCh WHERE SubcategorieCh='"+value.SubcategorieCh+"'").FirstOrDefault();  
                var sumRand= conn.Query<ValueModelCh>("SELECT SumaCh FROM ValueModelCh WHERE SubcategorieCh='"+value.SubcategorieCh+"'").FirstOrDefault();     

                ValueModelCh obiectDeUpdatat = conn.Query<ValueModelCh>("UPDATE ValueModelCh SET SumaCh=(SELECT SUM("+value.SumaCh+","+sumRand+") WHERE IdCh="+ idRand.IdCh).FirstOrDefault();
                //SQLite.SQLiteException: 'incomplete input'
                return obiectDeUpdatat;
            }
        }

    }
}
