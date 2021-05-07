using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FinantePersonale.ViewModels
{
    class BugetVM: INotifyPropertyChanged
    {
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Buget.txt");

        private string bugetL; 
        public string BugetL
        {
            get => bugetL;
            set
            {
                if (bugetL == value)
                    return;

                bugetL = value;
                OnPropertyChanged(nameof(BugetL));
            }
        }

        ////TREBUIE SA IAU VALOAREA DIN FILA SI SA O ADAUG INTR-O VARIABILA

        //int BugetAn= Int16.Parse(BugetL.ToString()) * 12;


        public event PropertyChangedEventHandler PropertyChanged;


        void OnPropertyChanged(string buget)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(buget));
        }

        public BugetVM()
        {
            //GetValoareBugetL();

        }

        //private void GetValoareBugetL()
        //{ 
        //   string sumaDinFile = File.ReadAllText(fileName);
        //}


    }
}
