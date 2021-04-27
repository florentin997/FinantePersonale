using System;
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
//using FinantePersonale.Services;

namespace FinantePersonale.ViewModels
{
    public class CheltuieliVM : BaseViewModel //ObservableCollection<ValueModelCh>
    {

        ////////////////////////////////------------------------------ luate din ItemsViewModel App2 
        //private ValueModelCh _selectedItem;
        //public ObservableCollection<ValueModelCh> Items { get; }
        //public Command LoadItemsCommand { get; }
        //public Command AddItemCommand { get; }
        //public Command<ValueModelCh> ItemTapped { get; }


        //public ObservableCollection<string> SubcategoriiCheltuieli
        //{
        //    get;
        //    set;
        //}

        //public CheltuieliVM()
        //{
        //    Title = "Browse";
        //    Items = new ObservableCollection<ValueModelCh>();
        //    LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        //    //77777777777777777777777
        //    SubcategoriiCheltuieli = new ObservableCollection<string>();
        //    GetSubcategorieCheltuieli();
        //    //777777777777777777777777
        //    ItemTapped = new Command<ValueModelCh>(OnItemSelected);

        //    AddItemCommand = new Command(OnAddItem);
        //}

        //async Task ExecuteLoadItemsCommand()
        //{
        //    IsBusy = true;

        //    try
        //    {
        //        Items.Clear();
        //        var items = await DataStore.GetItemsAsync(true);
        //        foreach (var item in items)
        //        {
        //            Items.Add(item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        //public void OnAppearing()
        //{
        //    IsBusy = true;
        //    SelectedItem = null;
        //}

        //public ValueModelCh SelectedItem
        //{
        //    get => _selectedItem;
        //    set
        //    {
        //        SetProperty(ref _selectedItem, value);
        //        OnItemSelected(value);
        //    }
        //}

        //private async void OnAddItem(object obj)
        //{
        //    await Shell.Current.GoToAsync(nameof(IstoricCheltuieliVM));
        //}

        //async void OnItemSelected(ValueModelCh item)
        //{
        //    if (item == null)
        //        return;

        //    // This will push the ItemDetailPage onto the navigation stack
        //    //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        //}
        ///////////////////////--------------------------------------------------------------------------------------------------------------- pana aici

        public ObservableCollection<ValueModelCh> Expenses
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

        public Command PopUpAddCategorieCommand { get; set; }
        public Command SaveCheltuieliCommand { get; set; }
        public Command DeleteCheltuieliCommand { get; set; }
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
            DeleteCheltuieliCommand = new Command(DeleteRowCH);
            PopUpAddCategorieCommand = new Command(PopUpScreen);
            GetSubcategorieCheltuieli();

            //ChPerCategCommand = new Command(ChPeCategorie);
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
                    App.Current.MainPage.DisplayAlert("Succes", "Inregistrare a fost stearsa", "Ok");
                else
                    App.Current.MainPage.DisplayAlert("Eroare", "Inregistrarea nu a putut fi stearsa", "Ok");
            }
        }

        public void PopUpScreen()
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.PopUpCategorie());
        }


        //-----------UPDATE LA GRAFIC
        public Chart Chart { get; set; }


        //------------------------------

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
