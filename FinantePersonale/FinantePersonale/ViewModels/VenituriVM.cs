using System;
using System.Collections.ObjectModel;
namespace UdemyCourse.ViewModels
{
    public class VenituriVM
    {
        public ObservableCollection<string> SubcategorieV { get; set; }

        public VenituriVM()
        {
            GetSubcategorieV();
        }

        private void GetSubcategorieV()
        {
            SubcategorieV = new ObservableCollection<string>();
            /*
            Subcategorie.Add("Chirie");
            Subcategorie.Add("Salariu");
            Subcategorie.Add("Burse");
            Subcategorie.Add("Sporuri");
            Subcategorie.Add("Indemnizatii");
            Subcategorie.Add("Dobanzi");
            Subcategorie.Add("Active");
            Subcategorie.Add("Obligatiuni");
            Subcategorie.Add("Cryptomonede");
            */
        }
    }
}