using FinantePersonale.Models;
using FinantePersonale.ViewModels.Methods;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class CategorieVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Categorie> Categorii
        {
            get;
            set;
        }

        private string categoriePrincipala;
        public string CategoriePrincipala
        {
            get { return categoriePrincipala; }
            set 
            { 
                categoriePrincipala = value;
                OnPropertyChanged(nameof(CategoriePrincipala));
            }
            
        }

        private string numeSubcategorie;
        public string NumeSubcategorie
        {
            get { return numeSubcategorie; }
            set
            {
                numeSubcategorie = value;
                OnPropertyChanged(nameof(NumeSubcategorie));
            }
        }

        private Categorie itemCategorie;
        public Categorie ItemCategorie
        {
            get { return itemCategorie; }
            set
            {
                if (itemCategorie != null)
                {
                    itemCategorie = value;
                }
                itemCategorie = value;
                OnPropertyChanged(nameof(ItemCategorie));
            }
        }
        public ObservableCollection<string> ColectieCategorii      //<Categorie>
        {
            get;
            set;
        }

        public Command SaveCategorieCommand { get; set; }
        public Command DeleteCategorieCommand { get; set; }
        //public Command PullToRefershCommand { get; set; }

        public CategorieVM()
        {
            ColectieCategorii = new ObservableCollection<string>();
            SaveCategorieCommand = new Command(InsertCategorie);
            DeleteCategorieCommand = new Command(DeleteRowCategorie);
            Categorii = new ObservableCollection<Categorie>();
            ListaCategorii();
        }

        public void InsertCategorie()  
        {
            Categorie categ = new Categorie()
            {
                CategoriePrincipala = CategoriePrincipala,
                NumeSubcategorie = NumeSubcategorie,
            };
            if(CategoriePrincipala == null || NumeSubcategorie == null)
            {
                Application.Current.MainPage.DisplayAlert("Eroare", "Nu ai completat toate câmpurile necesare", "OK");
            }
            else
            {
                if (MetodeCategorie.ExistaInregistrare(categ) == true)
                {
                    Application.Current.MainPage.DisplayAlert("Eroare", "Aceste date au mai fost introduse", "OK");
                }
                else
                {
                    int response = MetodeCategorie.InsertValue(categ);
                    if (response > 0)
                        Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuată", "OK");
                    else
                        Application.Current.MainPage.DisplayAlert("Eroare", "Salvare eșuată", "Ok");
                }
            }   
        }

        public void DeleteRowCategorie()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                int rows = conn.Delete(ItemCategorie);   
                if (rows > 0)
                    App.Current.MainPage.DisplayAlert("Succes", "Înregistrare a fost ștearsă", "Ok");
                else
                    App.Current.MainPage.DisplayAlert("Eroare", "Înregistrarea nu a putut fi ștearsă", "Ok");
            }
        }

        private void ListaCategorii()
        {
            ColectieCategorii.Clear();
            ColectieCategorii.Add("Venituri");
            ColectieCategorii.Add("Cheltuieli");
        }
    }
    //------------------------------------------------------------------

    public class IstoricCategoriiVM
    {
        public ObservableCollection<Categorie> IstCategorii
        {
            get;
            set;
        }
        public IstoricCategoriiVM()
        {
            IstCategorii = new ObservableCollection<Categorie>();

            GetIstCateg();
        }
        private void GetIstCateg()
        {
            var categorie = MetodeCategorie.GetValue();

            IstCategorii.Clear();

            foreach (var income in categorie)
            {
                IstCategorii.Add(income);
            }
        }
    }
}
