using System;
using System.Collections.ObjectModel;
using FinantePersonale.Models;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class CheltuieliVM
    {
        public ObservableCollection<Cheltuieli> Expenses
        {
            get;
            set;
        }

        public CheltuieliVM()
        {
            GetExpenses();
        }

        private void GetExpenses()
        {
            var expenses = Cheltuieli.GetExpenses();

            Expenses.Clear();

            foreach (var expense in expenses)
            {
                Expenses.Add(expense);
            }
        }

        public void AdaugareCheltuieli()
        {
            Application.Current.MainPage.Navigation.PushAsync(new CheltuieliVM());
        }
    }
}
