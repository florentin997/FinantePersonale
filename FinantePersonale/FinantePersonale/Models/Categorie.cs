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
        public int Id { get; set; }                         //id-ul
        [MaxLength(10), NotNull]
        public string CategoriePrincipala { get; set; }     //daca e venit sau cheltuiala
        [MaxLength(20), NotNull]
        public string NumeSubcategorie { get; set; }        //denumriea categoriei 
        public Categorie()
        {

        }
    }
}
