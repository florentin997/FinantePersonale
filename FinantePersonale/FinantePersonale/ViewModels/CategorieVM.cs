﻿using FinantePersonale.Models;
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
                OnPropertyChanged("CategoriePrincipala");
            }
            
        }

        private string numeSubcategorie;

        public string NumeSubcategorie
        {
            get { return numeSubcategorie; }
            set
            {
                numeSubcategorie = value;
                OnPropertyChanged("NumeSubcategorie");
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
                OnPropertyChanged("itemCh");
            }
        }
        public ObservableCollection<Categorie> CategoriiCollection    
        {
            get;
            set;
        }

        public Command SaveCategorieCommand { get; set; }
        public Command DeleteCategorieCommand { get; set; }

        public CategorieVM()
        {
            CategoriiCollection = new ObservableCollection<Categorie>();
            SaveCategorieCommand = new Command(InsertCheltuieli);
            DeleteCategorieCommand = new Command(DeleteRowCategorie);

        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void InsertCheltuieli()
        {
            Categorie categ = new Categorie()     
            {
                CategoriePrincipala = CategoriePrincipala,
                NumeSubcategorie = NumeSubcategorie,
            };
            int response = Categorie.InsertValue(categ);

            if (response > 0)
                //Application.Current.MainPage.Navigation.PopAsync();
                Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
            else
                Application.Current.MainPage.DisplayAlert("Error", "Salvare esuata", "Ok");
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

    }

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
