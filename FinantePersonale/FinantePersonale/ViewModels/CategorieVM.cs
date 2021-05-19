using FinantePersonale.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class CategorieVM //: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

            //----------------sa incerc sa bag date intr-un obsColl de tipul Categorie 
            Categorii = new ObservableCollection<Categorie>();
            //--------------pana aici

            //GetCategoriePrincipala();
            ListaCategorii();
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void InsertCategorie()  // in cazul in care nu mai merge, mergea cand a fost InsertCheltuieli
        {
            Categorie categ = new Categorie()
            {
                CategoriePrincipala = CategoriePrincipala,
                NumeSubcategorie = NumeSubcategorie,
            };

            if(CategoriePrincipala == null || NumeSubcategorie == null)
            {
                Application.Current.MainPage.DisplayAlert("Eroare", "Nu ai completat toate campurile necesare", "OK");
            }
            //daca in BD nu sunt date, insereaza datele fara a mai verifica pentru duplicate
            //if (Categorie.VerificareDacaBGEsteGoala() == false)
            //{
            //    int response = Categorie.InsertValue(categ);

            //    if (response > 0)
            //        Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
            //    else
            //        Application.Current.MainPage.DisplayAlert("Error", "Salvare esuata", "Ok");
            //}

            //altfel verifica daca exista duplicate
            else
            {
                if (Categorie.ExistaInregistrare(categ) == true)
                {
                    Application.Current.MainPage.DisplayAlert("Eroare", "Aceste date au mai fost introduse", "OK");
                }
                else
                {
                    int response = Categorie.InsertValue(categ);

                    if (response > 0)
                        Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
                    else
                        Application.Current.MainPage.DisplayAlert("Error", "Salvare esuata", "Ok");
                }
            }   
        }

        public void DeleteRowCategorie()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                int rows = conn.Delete(ItemCategorie);   

                if (rows > 0)
                    App.Current.MainPage.DisplayAlert("Succes", "Inregistrare a fost stearsa", "Ok");
                else
                    App.Current.MainPage.DisplayAlert("Eroare", "Inregistrarea nu a putut fi stearsa", "Ok");
            }
        }

        private void ListaCategorii()
        {
            ColectieCategorii.Clear();
            ColectieCategorii.Add("Venituri");
            ColectieCategorii.Add("Cheltuieli");
        }
    }
    //-----------------luate din ObsColl--------------------------------------


    //---------------pana aici------------------------------------------------

    //-----------------------------------

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

            GetIncome();
        }

        private void GetIncome()
        {
            var categorie = Categorie.GetValue();

            IstCategorii.Clear();

            foreach (var income in categorie)
            {
                IstCategorii.Add(income);
            }
        }

    }



}
