using System;
using Xamarin.Forms;
using System.IO;
using System.ComponentModel;
using Xamarin.Essentials;

namespace FinantePersonale.ViewModels
{
    class BugetVM : INotifyPropertyChanged //ObservableCollection
    {
        //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Buget.txt");
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

        //public string valoareDiferentaVC
        //{
        //    get
        //    {
        //        return Methods.Metode.DiferentaCV();
        //    }
        //}

        //---------incercare conectare la Assets Buget

        //public  void SaveCountAsync(string BugetL)
        //{
        //    var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Buget.txt");
        //    using (var writer = File.CreateText(backingFile))
        //    {
        //         writer.WriteLineAsync(BugetL.ToString());
        //    }
        //}
        //----------------pana aici-------


        public event PropertyChangedEventHandler PropertyChanged;
        public Command SaveBugetCommand { get; set; }
        public Command DeleteBugetCommand { get; set; }
        public BugetVM()
        {
            //SaveBugetCommand = new Command(CreateFile);   
            GetValoareBugetL();
            //ReadBuget();

            //------ delete command ptr numarul din fisier/db
            DeleteBugetCommand = new Command(DeleteRowItem);
        }

        //--METODA DE STERGERE DIN FISIER/DB
        public void DeleteRowItem()
        {

        }

        void OnPropertyChanged(string buget)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(buget));
        }

        //NU INTRODUCE BugelL IN  FILA
        //private void CreateFile()
        //{
        //    var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Buget.txt");

        //    if (backingFile == null || !File.Exists(backingFile))
        //    {
        //        File.Create(backingFile);
        //    }

        //    using (var writer = File.CreateText(backingFile))
        //    {
        //         writer.WriteLine(BugetL);
        //    }
            //bool doesExist = File.Exists(fileName);
            //if (!doesExist)
            //{
            //    File.WriteAllText(fileName, BugetL.ToString());
            //    Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata cu succes", "Ok");
            //}
            //else
            //    Application.Current.MainPage.DisplayAlert("Eroare", "Salvare esuata", "Ok");
        //}
        //    string ReadBuget()
        //    {
        //        var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Buget.txt");

        //        if (backingFile == null || !File.Exists(backingFile))
        //        {
        //            return "";
        //        }

        //        string content;
        //        using (var reader = new StreamReader(backingFile, true))
        //        {
        //            content = reader.ReadToEnd();
        //        }

        //        return content;
        //    }
        
        private void GetValoareBugetL()
        {
            bool doesExist = File.Exists(fileName);
            string sumaDinFile;
            if (doesExist)
            {
                sumaDinFile = File.ReadAllText(fileName);
            }
        }
    }
}
