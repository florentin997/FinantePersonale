using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FinantePersonale.Models;
using FinantePersonale.ViewModels.Commands;
using SQLite;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class CheltuieliVM : INotifyPropertyChanged
    {
        //public DeleteCommand DeleteCommand{get; set;}

        //public ValueModelCh inregistrare { get; set; }
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
                //if (subcategorie == value)
                //    return;

                //------------------
                //inregistrare = new ValueModelCh
                //{
                //    SubcategorieCh = this.SubcategorieC,
                //    SumaCh = this.SumaC
                //};
                //------------------
                subcategorie = value;
                OnPropertyChanged("SubcategorieC");
            }
        }


        private float sumaCheltuieli;
        public float SumaC
        {
            get { return sumaCheltuieli; }
            set
            {
                //if (sumaCheltuieli == value)
                //    return;
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
                //if (cheltuieliDate == value)
                //    return;
                cheltuieliDate = value;
                OnPropertyChanged("DateC");
            }
        }

        private ValueModelCh itemCh;

        public ValueModelCh ItemCh
        {
            get { return itemCh; }
            set {
                if (itemCh != null)
                {
                    itemCh = value;
                }
                itemCh = value;
                OnPropertyChanged("itemCh");   
            }
        }

        public Command SaveCheltuieliCommand { get; set; }
        public Command DeleteCheltuieliCommand { get; set; }

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
            DeleteCheltuieliCommand = new Command(DeleteRowCH);
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
            ValueModelCh ch = new ValueModelCh()     
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
                Application.Current.MainPage.DisplayAlert("Error", "Salvare esuata", "Ok");
        }


        
    public void DeleteRowCH()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                int rows = conn.Delete(ItemCh);   

                if (rows > 0)
                   App.Current.MainPage.DisplayAlert("Success", "Item succesfully deleted", "Ok");
                else
                    App.Current.MainPage.DisplayAlert("Failure", "Item failed to be deleted", "Ok");
            }
        }


        //PTR TESTARE
        //TREBUIE INLOCUIT CU O TABELA DE DATE PENTRU SUBCATEGORII
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
