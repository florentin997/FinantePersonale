using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UdemyCourse.ViewModels
{
    class IstoricCheltuieliVM
    {
        public ObservableCollection<string> SubcategorieC { get; set; }

        public IstoricCheltuieliVM()
        {
            GetSubcategorieC();
        }

        private void GetSubcategorieC()
        {
            SubcategorieC = new ObservableCollection<string>();
            /*
            Subcategorie.Add("Chirie");
            Subcategorie.Add("Mancare");
            Subcategorie.Add("Haine");
            Subcategorie.Add("Divertisment");
            Subcategorie.Add("Utilitati");
            */
        }
    }
}
