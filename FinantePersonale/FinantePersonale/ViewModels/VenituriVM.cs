using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FinantePersonale.Models;
using SQLite;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class VenituriVM : INotifyPropertyChanged
    {
        public ObservableCollection<ValueModelVen> Expenses
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


        private float sumaVenituri;   
        public float SumaV
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

        private ValueModelVen itemVen;
        public ValueModelVen ItemVen
        {
            get { return itemVen; }
            set
            {
                if (itemVen != null)
                {
                    itemVen = value;
                }
                itemVen = value;
                OnPropertyChanged("itemCh");
            }
        }
        public Command SaveVenituriCommand { get; set; }
        public Command DeleteVenituriCommand { get; set; }
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
            DeleteVenituriCommand = new Command(DeleteRowVen);
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
            ValueModelVen vn = new ValueModelVen()
            {
                Subcategorie = SubcategorieV,
                Suma = SumaV,
                Date = DateV
            };
            int response = ValueModelVen.InsertValue(vn);

            if (response > 0)
                Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
            else
                Application.Current.MainPage.DisplayAlert("Error", "Salvare esuata", "Ok");
        }

        public void DeleteRowVen()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                int rows = conn.Delete(ItemVen);

                if (rows > 0)
                    App.Current.MainPage.DisplayAlert("Success", "Item succesfully deleted", "Ok");
                else
                    App.Current.MainPage.DisplayAlert("Failure", "Item failed to be deleted", "Ok");
            }
        }


        private void GetSubcategorieVenituri()    //TREBUIE INLOCUIT CU O BAZA DE DATE PENTRU CATEGORII
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
