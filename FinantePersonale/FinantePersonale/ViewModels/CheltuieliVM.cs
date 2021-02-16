using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FinantePersonale.Models;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class CheltuieliVM
    {
        public ObservableCollection<ValueModel> Expenses
        {
            get;
            set;
        }


        //PROPRIETATILE AICI
        private string subcategorie;
        public string Subcategorie
        {
            get { return subcategorie; }
            set
            {
                subcategorie = value;
                OnPropertyChanged("ExpenseName");
            }
        }


        private decimal sumaCheltuieli;   //POSIBIL SA FIE NECESAR FLOAT PTR GRAFICE
        public decimal SumaCheltuieli
        {
            get { return sumaCheltuieli; }
            set
            {
                sumaCheltuieli = value;
                OnPropertyChanged("ExpenseAmmount");
            }
        }

        private DateTime expenseDate;
        public DateTime ExpenseDate
        {
            get { return expenseDate; }
            set
            {
                expenseDate = value;
                OnPropertyChanged("ExpenseDate");
            }
        }

        public Command SaveCheltuieliCommand { get; set; }

        public CheltuieliVM()
        {
            //Expenses = new ObservableCollection<Cheltuieli>();
            SaveCheltuieliCommand = new Command(InsertCheltuieli);
            //GetExpenses();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /*   PARTEA CU GET TREBUIE  PUSA LA ISTORIC, NU LA CHELTUIELIVM (de aici iau datele, nu le si afisez aici)
         *   
        private void GetExpenses()
        {
            var expenses = Cheltuieli.GetExpenses();

            Expenses.Clear();

            foreach (var expense in expenses)
            {
                Expenses.Add(expense);
            }
        }*/


        public void InsertCheltuieli()
        {
            ValueModel ch = new ValueModel()
            {
                Subcategorie = Subcategorie,
                Suma = SumaCheltuieli,
                Date=ExpenseDate
            };
            int response = ValueModel.InsertValue(ch);

            if (response > 0)
                Application.Current.MainPage.Navigation.PopAsync();
            else
                Application.Current.MainPage.DisplayAlert("Error", "No items were inserter", "Ok");
        }

        /* nav la pag noua, mai ma gandesc daca e necesara
        public void AdaugareCheltuieli()
        {
            Application.Current.MainPage.Navigation.PushAsync(new CheltuieliVM());
        }*/
    }
}
