using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FinantePersonale.Models;
using FinantePersonale.ViewModels.Commands;
using FinantePersonale.ViewModels.Methods;
using Microcharts;
using SQLite;
using Xamarin.Forms;
//using FinantePersonale.Services;

namespace FinantePersonale.ViewModels
{
    public class CheltuieliVM : INotifyPropertyChanged  //: ObservableCollection<ValueModelCh>
    {
        private string subcategorie;
        public string SubcategorieC
        {
            get { return subcategorie; }
            set
            {
                subcategorie = value;
                CallPropertyChanged(nameof(SubcategorieC));
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
                CallPropertyChanged(nameof(SumaC));
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
                CallPropertyChanged(nameof(DateC));
            }
        }

        private ValueModelCh itemCh;
        public ValueModelCh ItemCh
        {
            get { return itemCh; }
            set
            {
                //if (itemCh != null)
                //{
                //    itemCh = value;
                //}
                itemCh = value;
                CallPropertyChanged(nameof(itemCh));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public DeleteCommand DeleteItemCommand { get; set; } 
        //public Command PopUpAddCategorieCommand { get; set; }
        public Command SaveCheltuieliCommand { get; set; }
        //public Command RefreshCommand { get; set; }
        public Command DeleteCheltuieliCommand { get; set; }
        //public Command ChPerCategCommand { get; set; }

        public ObservableCollection<string> SubcategoriiCheltuieli    //trebuie pus ValueModelCh in loc de string!
        {
            get;
            set;
        }

     

        //AR TREBUI SA FAC ON OBSCOLLECTION CU OBIECTE DE TIPUL VALLUEMODELCH CARE SA SE UPDATEZE CAND SE UPDATEAZA SI DATELE INDIVIDUALE DE MAI SUS ?
        public CheltuieliVM()
        {
            SubcategoriiCheltuieli = new ObservableCollection<string>();
            DateC = DateTime.Today;
            SaveCheltuieliCommand = new Command(InsertCheltuieli);
            DeleteCheltuieliCommand = new Command(DeleteRowCH); //modul veche de delete, cel fara comanda
            GetSubcategorieCheltuieli();
            //RefreshCommand = new Command(Refresh);
            //Refresh();
            
            IstCheltuieli = new ObservableCollection<ValueModelCh>();
            GetCh();
            //-----
            //this.DeleteItemCommand = new DeleteCommand(this);
            //DeleteItemFromObsColl();

            ////Diferenta dintre V si C pe luna
            //EconPerLuna = new ObservableCollection<ValueModelCh>();
            //DiferentaLunara(DateTime.Today.Month.ToString());
        }

        //-----------ObservableCollection luat din IstCheltuieliiVM
        public ObservableCollection<ValueModelCh> IstCheltuieli
        {
            get;
            set;
        }
        private void GetCh()
        {
            var expenses = MetodeCh.GetValue();

            IstCheltuieli.Clear();

            foreach (var expense in expenses)
            {
                IstCheltuieli.Add(expense);
            }
        }
        //---------------
        //private float suma()
        //{
        //    float sum = 0;
        //    foreach (var c in IstCheltuieli)
        //    {
        //        sum = sum + c.SumaCh;
        //    }
        //    return sum;
        //}
        //-------------------
        private float s()
        {
            float sum = 0;
            foreach (var c in IstCheltuieli)
            {
                sum = sum + c.SumaCh;
            }
            return sum;
        }

        public float TotalSumaCh
        {
            get 
            {
                return s();
            }
            set 
            {            
                value = s();
                CallPropertyChanged(nameof(TotalSumaCh));
            }
        }

        public void InsertCheltuieli()
        {
            ValueModelCh ch = new ValueModelCh()
            {
                SubcategorieCh = SubcategorieC,
                SumaCh = SumaC,
                DateCh = DateC
            };
            IstCheltuieli.Add(ch);
            int response = MetodeCh.InsertValue(ch);

            if (response > 0)
            {
                TotalSumaCh = 0;      //IMPORTANT-> forteaza apelarea ptr recalcularea valorii
                Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
            }
               
            else
                Application.Current.MainPage.DisplayAlert("Eroare", "Salvare esuata", "Ok");
        }

        public void DeleteRowCH()
        {
            
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                int rows = conn.Delete(ItemCh);

                if (rows > 0) 
                {
                    GetCh();
                    TotalSumaCh = 0;
                    App.Current.MainPage.DisplayAlert("Succes", "Inregistrare a fost stearsa", "Ok");
                }
                else
                    App.Current.MainPage.DisplayAlert("Eroare", "Inregistrarea nu a putut fi stearsa", "Ok");
            }
            //TotalSumaCh = TotalSumaCh - ItemCh.SumaCh;
            //IstCheltuieli.Remove(ItemCh);
            
        }

        //-------------legat de comanda din commands

        //public void DeleteMethod(ValueModelCh value)
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        int rows = conn.Delete(ItemCh);

        //        if (rows > 0)
        //            App.Current.MainPage.DisplayAlert("Succes", "Inregistrare a fost stearsa", "Ok");
        //        else
        //            App.Current.MainPage.DisplayAlert("Eroare", "Inregistrarea nu a putut fi stearsa", "Ok");
        //    }
        //}
        //-------------pana aici

        private  void GetSubcategorieCheltuieli()            
        {
            try
            {
                var categorie = MetodeCategorie.GetValue("Cheltuieli");

                SubcategoriiCheltuieli.Clear();

                foreach (var c in categorie)
                {
                    SubcategoriiCheltuieli.Add(c.NumeSubcategorie);
                }
            }
            catch(Exception e)
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


        //-------------Picker-ul ptr ani----------
        private static List<string> l() //Lista ultimilor 10 ani fata de anul curent 
        {
            List<string> lAni= new List<string>();
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

        //-----------------SearchBar-------------
        //public ICommand PerformSearch => new Command<string>((string query) =>
        //{
        //    SearchResults = DataService.GetSearchResults(query);
        //});

        //private List<string> searchResults = DataService.Fruits;
        //public List<string> SearchResults
        //{
        //    get
        //    {
        //        return searchResults;
        //    }
        //    set
        //    {
        //        searchResults = value;
        //        NotifyPropertyChanged();
        //    }
        //}
        //----------------- SB pana aici----------------------

        /// <summary>
        /// Insert dupa ce verifica daca exista deja inregistrare cu Subcategoria respectiva, daca exista, fa update la 
        /// </summary>
        /// <param name="value"></param>
        //public void InsertCheltuieli()
        //{
        //    ValueModelCh ch = new ValueModelCh()
        //    {
        //        SubcategorieCh = SubcategorieC,
        //        SumaCh = SumaC,
        //        DateCh = DateC
        //    };

        //    if (Metode.ExistaInregistrareCh(ch) == true)   // DE VERIFICAT LOGICA CU TRUE SI FALSE AICI, NU-S SIGUR DACA E BINE ASA CUM E 
        //    {
        //        int response = ValueModelCh.InsertValue(ch);

        //        if (response > 0)
        //            Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
        //        else
        //            Application.Current.MainPage.DisplayAlert("Eroare", "Salvare esuata", "Ok");
        //    }

        //   else
        //    {
        //        var obiectUpdatat = Metode.UpdateCh(ch);

        //        int response = ValueModelCh.InsertValue(obiectUpdatat);

        //        if (response > 0)
        //            Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
        //        else
        //            Application.Current.MainPage.DisplayAlert("Eroare", "Salvare esuata", "Ok");
        //    }
        //}

    }
}
