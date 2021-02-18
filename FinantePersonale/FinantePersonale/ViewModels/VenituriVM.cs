using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FinantePersonale.Models;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class VenituriVM : INotifyPropertyChanged
    {
        public ObservableCollection<ValueModel> Expenses
        {
            get;
            set;
        }

        private string subcategorie;
        public string SubcategorieV
        {
            get { return subcategorie; }
            set
            {
                subcategorie = value;
                OnPropertyChanged("SubcategorieV");
            }
        }


        private decimal sumaVenituri;   
        public decimal SumaV
        {
            get { return sumaVenituri; }
            set
            {
                sumaVenituri = value;
                OnPropertyChanged("SumaV");
            }
        }

        private DateTime venituriDate;
        public DateTime DateV
        {
            get { return venituriDate; }
            set
            {
                venituriDate = value;
                OnPropertyChanged("DateV");
            }
        }

        public Command SaveVenituriCommand { get; set; }
        //-----------
        public ObservableCollection<string> SubcategoriiVenituri
        {
            get;
            set;
        }//------------
        public VenituriVM()
        {
            SubcategoriiVenituri = new ObservableCollection<string>();
            DateV = DateTime.Today;
            SaveVenituriCommand = new Command(InsertVenituri);
            GetSubcategorieVenituri();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertVenituri()
        {
            ValueModel ch = new ValueModel()
            {
                Subcategorie = SubcategorieV,
                Suma = SumaV,
                Date = DateV
            };
            int response = ValueModel.InsertValue(ch);

            if (response > 0)
                Application.Current.MainPage.Navigation.PopAsync();
            else
                Application.Current.MainPage.DisplayAlert("Error", "Insertie esuata", "Ok");
        }

        private void GetSubcategorieVenituri()
        {
            SubcategoriiVenituri.Clear();
            SubcategoriiVenituri.Add("Salariu");
            SubcategoriiVenituri.Add("Sporuri");
            SubcategoriiVenituri.Add("Indemnizatii");
            SubcategoriiVenituri.Add("Dividende");
            SubcategoriiVenituri.Add("Actiuni");
            SubcategoriiVenituri.Add("Cryptomonede");
            SubcategoriiVenituri.Add("Altele");
        }
    }
}
