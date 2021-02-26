using FinantePersonale.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class IstoricVenituriVM
    {
        public ObservableCollection<ValueModelVen> IstVenituri
        {
            get;
            set;
        }

        public Command AddExpenseCommand
        {
            get;
            set;
        }

        public IstoricVenituriVM()
        {
            IstVenituri = new ObservableCollection<ValueModelVen>();

            GetExpenses();
        }

        private void GetExpenses()
        {
            var expenses = ValueModelVen.GetValue();

            IstVenituri.Clear();

            foreach (var expense in expenses)
            {
                IstVenituri.Add(expense);
            }
        }
    }
}
