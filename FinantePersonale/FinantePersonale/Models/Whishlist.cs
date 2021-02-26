
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinantePersonale.Models
{
    class Whishlist
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Item { get; set; }
        public float Procent { get; set; }


    }
}
