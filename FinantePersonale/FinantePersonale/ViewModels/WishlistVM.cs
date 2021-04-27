using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using FinantePersonale.Models;
using SQLite;
using Xamarin.Forms;
using FinantePersonale.Views;
using System.Threading.Tasks;

namespace FinantePersonale.ViewModels
{
    public class WishlistVM : INotifyPropertyChanged
    {

        public ObservableCollection<ModelWishlist> WishlistItems
        {
            get;
            set;
        }

      
        private int itemID;
        public int ItemID
        {
            get { return itemID; }
            set
            {
                itemID = value;
                OnPropertyChanged("ItemID");
            }
        }

        private string itemW;
        public string ItemW
        {
            get { return itemW; }
            set
            {
                itemW = value;
                OnPropertyChanged("ItemW");
            }
        }

        private float ivalue;

        public float IValue
        {
            get { return ivalue; }
            set 
            { 
                ivalue = value;
                OnPropertyChanged("IValue");
            }
        }
        

        private ModelWishlist itemToDelete;

        public ModelWishlist ItemToDelete
        {
            get { return itemToDelete; }
            set {
                if(itemToDelete != null)
                {
                    itemToDelete = value;
                }
                itemToDelete = value;
                OnPropertyChanged("ItemToDelete");
            }
        }

        public Command SaveWishlistItemCommand { get; set; }
        public Command DeleteItemFromWLCommand { get; set; }
        public Command RefreshCommand { get; set; }
        //public Command UpdateWishlistCommand { get; set; }


        public WishlistVM()
        {
            WishlistItems = new ObservableCollection<ModelWishlist>();
            DeleteItemFromWLCommand = new Command(DeleteRowItem);
            SaveWishlistItemCommand = new Command(InsertItem);
            RefreshCommand = new Command(RefreshWishlist);
            //UpdateWishlistCommand = new Command(UpdateList);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertItem()  
        {
            ModelWishlist givenItem = new ModelWishlist()
            {
                ItemName = ItemW,           
                ItemValue = IValue
            };
            int response = ModelWishlist.InsertValue(givenItem);

            if (response > 0)
                Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
            else
                Application.Current.MainPage.DisplayAlert("Error", "Salvare esuata", "Ok");
        }

        public void DeleteRowItem()  
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                int rows = conn.Delete(ItemToDelete);

                if (rows > 0)
                    App.Current.MainPage.DisplayAlert("Succes", "Inregistrare a fost stearsa", "Ok");
                else
                    App.Current.MainPage.DisplayAlert("Eroare", "Inregistrarea nu a putut fi stearsa", "Ok");
            }
        }

        public void RefreshWishlist()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                 
               //verific daca ce am in BD e acelasi cu ce am in View si daca nu, adaug ultimul element?
            }
        }

        //------
        //-----------

        //public void  UpdateList()
        //{

        //        var posts =  ModelWishlist.Read();
        //        if (posts != null)
        //        {
        //            WishlistItems.Clear();
        //            foreach (var post in posts)
        //                WishlistItems.Add(post);
        //        }
        //}
        ////------------------


        //------
    }


    /// <summary>
    ///Partea asta de cod se ocupa de obtinerea valorilor din BD
    /// </summary>
    //public class ListaObiectelor:ObservableCollection<ModelWishlist>
    //{
    //    public ObservableCollection<ModelWishlist> ItemsList
    //    {
    //        get;
    //        set;
    //    }

    //    public Command AddItemCommand
    //    {
    //        get;
    //        set;
    //    }

    //    public ListaObiectelor()
    //    {
    //        ItemsList = new ObservableCollection<ModelWishlist>();

    //        GetItems();
    //    }

    //    private void GetItems()
    //    {
    //        var items = ModelWishlist.GetValue();

    //        ItemsList.Clear();

    //        foreach (var item in items)
    //        {
    //            ItemsList.Add(item);
    //        }
    //    }
    //}
}
