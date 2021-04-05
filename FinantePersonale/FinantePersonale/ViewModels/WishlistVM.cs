using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using FinantePersonale.Models;
using SQLite;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class WishlistVM : INotifyPropertyChanged
    {

        public ObservableCollection<ModelWishlist> WishlistItems
        {
            get;
            set;
        }

        //-----------------------
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
        //-----------------------

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

        private float ivalue; //=99.99f;

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

        public ObservableCollection<string> WishlistItem  
        {
            get; 
            set; 
        }

        public WishlistVM()
        {
            WishlistItem = new ObservableCollection<string>();
            DeleteItemFromWLCommand = new Command(DeleteRowItem);
            SaveWishlistItemCommand = new Command(InsertItem);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertItem()
        {
            ModelWishlist givenItem = new ModelWishlist()
            {
                ItemName = ItemW,           
                ItemValue = float.Parse(IValue.ToString()),
            };
            int response = ModelWishlist.InsertValue(givenItem);

            if (response > 0)
                //Application.Current.MainPage.Navigation.PopAsync();
                Application.Current.MainPage.DisplayAlert("Succes", "Salvare efectuata", "OK");
            else
                Application.Current.MainPage.DisplayAlert("Error", "Salvare esuata", "Ok");
        }

        //---------------------------------------
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
