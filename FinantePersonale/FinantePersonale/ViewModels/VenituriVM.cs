using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FinantePersonale.Models;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class VenituVM
    {
        public ObservableCollection<ValueModel> Expenses
        {
            get;
            set;
        }

        private string subcategorie;
        public string Subcategorie
        {
            get { return subcategorie; }
            set
            {
                subcategorie = value;
                OnPropertyChanged("SubcategorieVenituri");
            }
        }


        private decimal venituriSuma;   
        public decimal SumaVenituri
        {
            get { return venituriSuma; }
            set
            {
                venituriSuma = value;
                OnPropertyChanged("SumaVenituri");
            }
        }

        private DateTime venituriDate;
        public DateTime VenituriDate
        {
            get { return venituriDate; }
            set
            {
                venituriDate = value;
                OnPropertyChanged("VenituriDate");
            }
        }

        public Command SaveVenituriCommand { get; set; }

        public VenituVM()
        {
            SaveVenituriCommand = new Command(InsertVenituri);
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
                Subcategorie = Subcategorie,
                Suma = venituriSuma,
                Date = VenituriDate
            };
            int response = ValueModel.InsertValue(ch);

            if (response > 0)
                Application.Current.MainPage.Navigation.PopAsync();
            else
                Application.Current.MainPage.DisplayAlert("Error", "No items were inserter", "Ok");
        }
    }
}
