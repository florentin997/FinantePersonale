using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace FinantePersonale.Models
{
    //[Table("ValueModelCh")]
    public class ValueModelCh 
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int IdCh { get; set; }
        [NotNull]
        public string SubcategorieCh { get; set; }
        [NotNull]
        public float SumaCh { get; set; }
        [NotNull]
        public DateTime DateCh { get; set; }
        public ValueModelCh(){}
        //---------------pentru graficul Syncfusion
        //public ValueModelCh(string xValue, float yValue)
        //{
        //    SubcategorieCh = xValue;
        //    SumaCh = yValue;
        //}
    }
}
