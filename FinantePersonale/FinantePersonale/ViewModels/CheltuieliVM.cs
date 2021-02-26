using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FinantePersonale.Models;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class CheltuieliVM : INotifyPropertyChanged
    {
        public ObservableCollection<ValueModelVen> Expenses
        {
            get;
            set;
        }

        private string subcategorie;
        public string SubcategorieC
        {
            get { return subcategorie; }
            set
            {
                subcategorie = value;
                OnPropertyChanged("SubcategorieC");
            }
        }


        private decimal sumaCheltuieli;
        public decimal SumaC
        {
            get { return sumaCheltuieli; }
            set
            {
                sumaCheltuieli = value;
                OnPropertyChanged("SumaC");
            }
        }

        private DateTime cheltuieliDate;
        public DateTime DateC
        {
            get { return cheltuieliDate; }
            set
            {
                cheltuieliDate = value;
                OnPropertyChanged("DateC");
            }
        }

        public Command SaveCheltuieliCommand { get; set; }
        //-----------
        public ObservableCollection<string> SubcategoriiCheltuieli
        {
            get;
            set;
        }//------------
        public CheltuieliVM()
        {
            SubcategoriiCheltuieli = new ObservableCollection<string>();
            DateC = DateTime.Today;
            SaveCheltuieliCommand = new Command(InsertCheltuieli);
            GetSubcategorieCheltuieli();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertCheltuieli()
        {
            ValueModelCh ch = new ValueModelCh()     //**********
            {
                SubcategorieCh = SubcategorieC,
                SumaCh = SumaC,
                DateCh = DateC
            };
            int response = ValueModelCh.InsertValue(ch);

            if (response > 0)
                //Application.Current.MainPage.Navigation.PopAsync();
                Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
            else
                Application.Current.MainPage.DisplayAlert("Error", "Insertie esuata", "Ok");
        }

        //PTR TESTARE
        private void GetSubcategorieCheltuieli()            //TREBUIE INLOCUIT CU O BAZA DE DATE PENTRU CATEGORII
        {
            SubcategoriiCheltuieli.Clear();
            SubcategoriiCheltuieli.Add("Chirie");
            SubcategoriiCheltuieli.Add("Mancare");
            SubcategoriiCheltuieli.Add("Sanatate");
            SubcategoriiCheltuieli.Add("Recreatie");
            SubcategoriiCheltuieli.Add("Transport");
            SubcategoriiCheltuieli.Add("Calatorii");
            SubcategoriiCheltuieli.Add("Altele");
        }
    }
}
