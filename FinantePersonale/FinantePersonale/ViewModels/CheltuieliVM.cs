using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FinantePersonale.Models;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class CheltuieliVM : INotifyPropertyChanged
    {
        //PROPRIETATILE AICI
        private string subcategorie;
        public string SubcatergorieC
        {
            get { return subcategorie; }
            set
            {
                subcategorie = value;
                OnPropertyChanged("SubcatergorieC");
            }
        }


        private decimal sumaCheltuieli;   //POSIBIL SA FIE NECESAR FLOAT PTR GRAFICE
        public decimal SumaC
        {
            get { return sumaCheltuieli; }
            set
            {
                sumaCheltuieli = value;
                OnPropertyChanged("SumaC");
            }
        }

        private DateTime expenseDate;
        public DateTime DateC
        {
            get { return expenseDate; }
            set
            {
                expenseDate = value;
                OnPropertyChanged("DateC");
            }
        }

        public Command SaveCheltuieliCommand { get; set; }
        //------------
        public ObservableCollection<string> SubcategoriiCheltuieli{ get;set;}
        //-------------
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
            ValueModel ch = new ValueModel()
            {
                Subcategorie = SubcatergorieC,
                Suma = SumaC,
                Date=DateC
            };
            int response = ValueModel.InsertValue(ch);

            if (response > 0)
                //Application.Current.MainPage.Navigation.PopAsync();
                Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata cu succes", "ok");
            else
                Application.Current.MainPage.DisplayAlert("Error", "salvare esuata", "Ok");
        }


        private void GetSubcategorieCheltuieli()
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
