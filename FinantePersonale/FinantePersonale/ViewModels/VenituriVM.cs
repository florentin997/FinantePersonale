using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FinantePersonale.Models;
using FinantePersonale.ViewModels.Commands;
using Microcharts;
using SQLite;
using Xamarin.Forms;
namespace FinantePersonale.ViewModels
{
    public class VenituriVM //: INotifyPropertyChanged
    {

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

            IstVenituri = new ObservableCollection<ValueModelVen>();
            GetVen();

            DataVen = new ObservableCollection<ValueModelVen>();     
            FillData();
        }
        //----------------- ptr SF chart
        private void FillData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                foreach (var item in conn.Table<ValueModelVen>().ToList())
                {
                    ValueModelVen obj = new ValueModelVen()
                    {
                        SubcategorieVen = item.SubcategorieVen,
                        SumaVen = item.SumaVen,
                    };
                    DataVen.Add(obj);   //Datele sunt introduse in DataVen (am verificat cu breakpoint ptr fiecare), dar nu ajung in grafic
                }
            }
        }
        public ObservableCollection<ValueModelVen> DataVen { get; set; }

        public ObservableCollection<ValueModelVen> IstVenituri
        {
            get;
            set;
        }
        private void GetVen()
        {
            var venituri = ValueModelVen.GetValue();

            IstVenituri.Clear();

            foreach (var ven in venituri)
            {
                IstVenituri.Add(ven);
            }
        }
        //-------------------

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertVenituri()
        {
            ValueModelVen vn = new ValueModelVen()
            {
                SubcategorieVen = SubcategorieV,
                SumaVen = SumaV,
                DateVen = DateV
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


        private void GetSubcategorieVenituri()    //TREBUIE INLOCUIT CU O BAZA DE DATE PENTRU CATEGORII / sau le adaug intr-un file in file system
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
