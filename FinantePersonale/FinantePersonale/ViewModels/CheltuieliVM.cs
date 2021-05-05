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
//using FinantePersonale.Services;

namespace FinantePersonale.ViewModels
{
    public class CheltuieliVM //: ObservableCollection<ValueModelCh>
    {
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
            set
            {
                if (itemCh != null)
                {
                    itemCh = value;
                }
                itemCh = value;
                OnPropertyChanged("itemCh");
            }
        }

        public DeleteCommand DeleteItemCommand { get; set; } 
        public Command PopUpAddCategorieCommand { get; set; }
        public Command SaveCheltuieliCommand { get; set; }
        //public Command DeleteCheltuieliCommand { get; set; }
        //public Command ChPerCategCommand { get; set; }


        public ObservableCollection<string> SubcategoriiCheltuieli
        {
            get;
            set;
        }
        public CheltuieliVM()
        {
            SubcategoriiCheltuieli = new ObservableCollection<string>();
            DateC = DateTime.Today;
            SaveCheltuieliCommand = new Command(InsertCheltuieli);
            //DeleteCheltuieliCommand = new Command(DeleteRowCH); modul veche de delete, cel fara comanda
            //PopUpAddCategorieCommand = new Command(PopUpScreen);
            GetSubcategorieCheltuieli();

            IstCheltuieli = new ObservableCollection<ValueModelCh>();
            GetCh();
            //-----
            this.DeleteItemCommand = new DeleteCommand(this);
            //ChPerCategCommand = new Command(ChPeCategorie);

            //SF chart ObsCollection
            DataCh = new ObservableCollection<ValueModelCh>();
            FillData();

        }

        //-------SF adaugare date  in grafic
        private void FillData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                foreach(var item in conn.Table<ValueModelCh>().ToList())
                {
                    ValueModelCh obj = new ValueModelCh()
                    {
                        SubcategorieCh = item.SubcategorieCh,
                        SumaCh = item.SumaCh,
                    };
                    DataCh.Add(obj);
                }
            }
        }
        //------pana aici

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //-----------ObservableCollection 

        public ObservableCollection<ValueModelCh> IstCheltuieli
        {
            get;
            set;
        }
        private void GetCh()
        {
            var expenses = ValueModelCh.GetValue();

            IstCheltuieli.Clear();

            foreach (var expense in expenses)
            {
                IstCheltuieli.Add(expense);
            }
        }
        //-----------pana aici

        //public void InsertCheltuieli()
        //{
        //    ValueModelCh ch = new ValueModelCh()
        //    {
        //        SubcategorieCh = SubcategorieC,
        //        SumaCh = SumaC,
        //        DateCh = DateC
        //    };
        //    int response = ValueModelCh.InsertValue(ch);

        //    if (response > 0)
        //        Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
        //    else
        //        Application.Current.MainPage.DisplayAlert("Eroare", "Salvare esuata", "Ok");
        //}

        public void InsertCheltuieli()
        {
            ValueModelCh ch = new ValueModelCh()
            {
                SubcategorieCh = SubcategorieC,
                SumaCh = SumaC,
                DateCh = DateC
            };

            if (Metode.ExistaInregistrareCh(ch) == true)
            {
                int response = ValueModelCh.InsertValue(ch);

                if (response > 0)
                    Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
                else
                    Application.Current.MainPage.DisplayAlert("Eroare", "Salvare esuata", "Ok");
            }

           else
            {

                var obiectUpdatat = Metode.UpdateCh(ch);

                int response = ValueModelCh.InsertValue(obiectUpdatat);

                if (response > 0)
                    Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
                else
                    Application.Current.MainPage.DisplayAlert("Eroare", "Salvare esuata", "Ok");
            }
        }

        //public void DeleteRowCH()
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

        //-------------legat de comanda din commands

        public void DeleteMethod(ValueModelCh value)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                int rows = conn.Delete(ItemCh);

                if (rows > 0)
                    App.Current.MainPage.DisplayAlert("Succes", "Inregistrare a fost stearsa", "Ok");
                else
                    App.Current.MainPage.DisplayAlert("Eroare", "Inregistrarea nu a putut fi stearsa", "Ok");
            }
        }

        //-------------pana aici


        //public void PopUpScreen()
        //{
        //    App.Current.MainPage.Navigation.PushAsync(new Views.PopUpCategorie());
        //}

        //----- legat de graficul SF
        public ObservableCollection<ValueModelCh> DataCh { get; set; }

        //------pana aici



        //------------------------------ Valoare cheltuieli pe categorie 

        //public void ChPeCategorie()
        //{
        //    using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        var valCh = conn.Table<ValueModelCh>().ToList();

        //        var nr = (from c in valCh group c.SumaCh by c.SubcategorieCh).ToList();
        //    }
        //}

        //from c in valCh select count * groupby c.Value

        //PTR TESTARE
        //TREBUIE INLOCUIT CU O TABELA DE DATE PENTRU SUBCATEGORII
        private  void GetSubcategorieCheltuieli()            
        {
            SubcategoriiCheltuieli.Clear();
            SubcategoriiCheltuieli.Add("Chirie");
            SubcategoriiCheltuieli.Add("Mancare");
            SubcategoriiCheltuieli.Add("Sanatate");
            SubcategoriiCheltuieli.Add("Recreatie");
            SubcategoriiCheltuieli.Add("Transport");
            SubcategoriiCheltuieli.Add("Calatorii");
            SubcategoriiCheltuieli.Add("Altele");


            //TEORETIC l este o lista de nume de subcategorii de tip string . Lista ce trebuie adaugata in lista de subcategorii pentru Pickerul din Cheltuieli VM------------------------------

            //List<string> l = Categorie.CategoriiDeTipDat("Cheltuieli");
            //SubcategoriiCheltuieli.ToList().ForEach(l.Add);

            //----------------varianta asta nu da eroare
            //foreach (var c in l)
            //    SubcategoriiCheltuieli.Add(c);

            //aici iau valorile din tabela Categorie unde la coloana categorie apare "Cheltuieli"

        }
    }
}
