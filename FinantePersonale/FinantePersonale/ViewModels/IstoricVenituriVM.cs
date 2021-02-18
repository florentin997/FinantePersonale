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
        public ObservableCollection<ValueModel> IstVenituri
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
            IstVenituri = new ObservableCollection<ValueModel>();

            GetExpenses();
        }

        private void GetExpenses()
        {
            var expenses = ValueModel.GetValue();

            IstVenituri.Clear();

            foreach (var expense in expenses)
            {
                IstVenituri.Add(expense);
            }
        }
    }
}
