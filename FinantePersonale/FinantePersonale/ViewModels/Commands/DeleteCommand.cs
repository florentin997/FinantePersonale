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

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //var obiect = (ValueModelCh)parameter;
                
            //if(//string.IsNullOrEmpty(obiect.SubcategorieCh) || 
            //    string.IsNullOrEmpty(obiect.IdCh.ToString()))  
            //    //string.IsNullOrEmpty(obiect.SumaCh.ToString()))
            //{
            //    return false;
            //}
            return true; 
        }

        public void Execute(object parameter)
        {
            this.obiectDeSters.DeleteMethod(parameter as ValueModelCh);
        }
    }
}
