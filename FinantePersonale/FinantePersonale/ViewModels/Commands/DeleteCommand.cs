using FinantePersonale.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FinantePersonale.ViewModels.Commands
{
    public class DeleteCommand : ICommand
    {
        public CheltuieliVM obiectDeSters { get; set; }

        public DeleteCommand(CheltuieliVM obiect)
        {
            obiectDeSters = obiect;
        }
        public IstoricCheltuieliVM IstoricCheltuieliViewModel { get; set; }

        public DeleteCommand(IstoricCheltuieliVM item)
        {

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var obiect = (ValueModelCh)parameter;
                
            if(string.IsNullOrEmpty(obiect.SubcategorieCh) || 
                string.IsNullOrEmpty(obiect.IdCh.ToString()) || 
                string.IsNullOrEmpty(obiect.SumaCh.ToString()))
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                //conn.CreateTable<ModelWishlist>();
                int rows = conn.Delete(parameter);   //metoda delete primeste ca parametru obiectul ce trebuie sters

                if (rows > 0)
                    App.Current.MainPage.DisplayAlert("Success", "Item succesfully deleted", "Ok");
                else
                    App.Current.MainPage.DisplayAlert("Failure", "Item failed to be deleted", "Ok");
            }
        }
    }
}
