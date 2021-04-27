using FinantePersonale.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class IstoricCheltuieliVM :  BaseViewModel //ObservableCollection<ValueModelCh>
    {


        ////////////////------------------------COPIAT DIN NEWITEMVIEWMODEL APP2
        //private string subcategorieCh;
        //private float sumaCh;

        //public IstoricCheltuieliVM()
        //{
        //    SaveCommand = new Command(OnSave, ValidateSave);
        //    CancelCommand = new Command(OnCancel);
        //    this.PropertyChanged +=
        //        (_, __) => SaveCommand.ChangeCanExecute();
        //}

        //private bool ValidateSave()
        //{
        //    return !String.IsNullOrWhiteSpace(subcategorieCh)
        //        && !String.IsNullOrWhiteSpace(sumaCh.ToString());
        //}

        //public string Subcategorie
        //{
        //    get => subcategorieCh;
        //    set => SetProperty(ref subcategorieCh, value);
        //}

        //public float Suma
        //{
        //    get => sumaCh;
        //    set => SetProperty(ref sumaCh, value);
        //}

        //public Command SaveCommand { get; }
        //public Command CancelCommand { get; }

        //private async void OnCancel()
        //{
        //    // This will pop the current page off the navigation stack
        //    await Shell.Current.GoToAsync("..");
        //}

        //private async void OnSave()
        //{
        //    ValueModelCh newItem = new ValueModelCh()
        //    {
        //        SubcategorieCh = Subcategorie,
        //        SumaCh = Suma
        //    };

        //    await DataStore.AddItemAsync(newItem);

        //    // This will pop the current page off the navigation stack
        //    await Shell.Current.GoToAsync("..");
        //}
        /////////////////////-----------------------------------------------PANA AICI

        public ObservableCollection<ValueModelCh> IstCheltuieli
        {
            get;
            set;
        }

        public IstoricCheltuieliVM()
        {
            IstCheltuieli = new ObservableCollection<ValueModelCh>();

            GetExpenses();
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        private void GetExpenses()
        {
            var expenses = ValueModelCh.GetValue();

            IstCheltuieli.Clear();

            foreach (var expense in expenses)
            {
                IstCheltuieli.Add(expense);
            }
        }
    }
}
