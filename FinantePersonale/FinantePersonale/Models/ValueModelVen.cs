using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinantePersonale.Models
{
    [Table("ValueModelVen")]
    public class ValueModelVen
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string SubcategorieVen { get; set; }
        [NotNull]
        public float SumaVen { get; set; }
        [NotNull]
        public DateTime DateVen { get; set; }
        public ValueModelVen(){}
        //-----------pentru graficul Syncfusion 
        //public ValueModelVen(string xValue, float yValue)
        //{
        //    SubcategorieVen = xValue;
        //    SumaVen = yValue;
        //}
    }
}
