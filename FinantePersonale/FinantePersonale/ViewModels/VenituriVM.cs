using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FinantePersonale.Models;
using FinantePersonale.ViewModels.Commands;
using FinantePersonale.ViewModels.Methods;
using Microcharts;
using SQLite;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class VenituriVM : INotifyPropertyChanged
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

            //DataVen = new ObservableCollection<ValueModelVen>();     
            //FillData();
        }

        //----------------- ptr SF chart
        //private void FillData()
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        foreach (var item in conn.Table<ValueModelVen>().ToList())
        //        {
        //            ValueModelVen obj = new ValueModelVen()
        //            {
        //                SubcategorieVen = item.SubcategorieVen,
        //                SumaVen = item.SumaVen,
        //            };
        //            DataVen.Add(obj);   //Datele sunt introduse in DataVen (am verificat cu breakpoint ptr fiecare), dar nu ajung in grafic
        //        }
        //    }
        //}
        //public ObservableCollection<ValueModelVen> DataVen { get; set; }

        public ObservableCollection<ValueModelVen> IstVenituri
        {
            get;
            set;
        }
        private void GetVen()
        {
            var venituri = MetodeVen.GetValue();

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
        private float s()
        {
            float sum = 0;
            foreach (var c in IstVenituri)
            {
                sum = sum + c.SumaVen;
            }
            return sum;
        }

        public float TotalSumaVen
        {
            get
            {
                return s();
            }
            set
            {
                value = s();
                OnPropertyChanged("TotalSumaVen");
            }
        }
        public void InsertVenituri()
        {
            ValueModelVen vn = new ValueModelVen()
            {
                SubcategorieVen = SubcategorieV,
                SumaVen = SumaV,
                DateVen = DateV
            };
            IstVenituri.Add(vn);
            int response = MetodeVen.InsertValue(vn);

            if (response > 0) 
            {
                TotalSumaVen = 0;
                Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuată", "OK");
            }
            else
                Application.Current.MainPage.DisplayAlert("Eroare", "Salvare eșuată", "Ok");
        }

        public void DeleteRowVen()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                int rows = conn.Delete(ItemVen);
                IstVenituri.Remove(ItemVen);
                if (rows > 0)
                {
                    TotalSumaVen = 0;
                    App.Current.MainPage.DisplayAlert("Succes", "Înregistrare a fost ștearsă", "Ok");
                }
                else
                    App.Current.MainPage.DisplayAlert("Eroare", "Înregistrarea nu a putut fi ștearsă", "Ok");
            }
        }


        private void GetSubcategorieVenituri()    
        {
            try
            {
                var categorie = MetodeCategorie.GetValue("Venituri");

                SubcategoriiVenituri.Clear();

                foreach (var c in categorie)
                {
                    SubcategoriiVenituri.Add(c.NumeSubcategorie);
                }
            }
            catch (Exception e)
            { 
            //exceptie
            }
        }

        //Ptr picker-ul de luni-------------
        public List<string> listaLuni = new List<string> { "Ianuarie", "Februarie", "Martie", "Aprilie", "Mai", "Iunie", "Iulie", "August", "Septembrie", "Octombrie", "Noiembrie", "Decembrie" };
        public List<string> Month
        {
            get { return listaLuni; }
        }
        //------------ pana aici-------------

        //Picker-ul ptr ani----------
        private static List<string> l() //Lista ultimilor 10 ani fata de anul curent 
        {
            List<string> lAni = new List<string>();
            int d = Int16.Parse(DateTime.Now.Year.ToString());

            int i = Int16.Parse(DateTime.Now.Year.ToString()) - 2;
            do
            {
                lAni.Add(i.ToString());
                i++;
            }
            while (i <= d);
            return lAni;
        }
        public List<string> Year { get { return l(); } }
        //-----------------pana aici-----------------

    }
}
