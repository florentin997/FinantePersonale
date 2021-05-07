using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FinantePersonale.Models
{
    class ModelBuget
    {
        public string BugetZi { get; set; }
        public string BugetSaptamana { get; set; }
        public string BugetLuna { get; set; }
        public string BugetAn { get; set; }
        public string AlertaBuget { get; set; }
    }
}
