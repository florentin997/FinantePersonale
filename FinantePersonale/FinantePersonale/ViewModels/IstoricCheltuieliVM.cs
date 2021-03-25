using FinantePersonale.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class IstoricCheltuieliVM:ObservableCollection<ValueModelCh>
    {
        public ObservableCollection<ValueModelCh> IstCheltuieli
        {
            get;
            set;
        }

        public Command AddExpenseCommand
        {
            get;
            set;
        }

        public IstoricCheltuieliVM()
        {
            IstCheltuieli = new ObservableCollection<ValueModelCh>();

            GetExpenses();
        }

        private void GetExpenses()
        {
            var expenses = ValueModelCh.GetValue();

            IstCheltuieli.Clear();

            foreach (var expense in expenses)
            {
                IstCheltuieli.Add(expense);
            }
        }
        //------------------------------


    }
}
