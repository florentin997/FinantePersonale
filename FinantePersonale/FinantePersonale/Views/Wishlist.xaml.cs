
using FinantePersonale.Models;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data;
using System.Data.SqlTypes;
using System.ComponentModel;

namespace FinantePersonale.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Wishlist : ContentPage
    {
        //ModelWishlist listaDeDorinte;
        public Wishlist()
        {
            InitializeComponent();

            //listaDeDorinte = new ModelWishlist();
            //itemsListView.BindingContext = listaDeDorinte;
        }


        //------------------------------------------

        //public ModelWishlist itemForRemoval;
        //public void deleteButtonWishlist_Clicked(object sender, System.EventArgs e)
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        //conn.CreateTable<ModelWishlist>();
        //        int rows = conn.Delete(itemForRemoval);    //metoda delete primeste ca parametru obiectul ce trebuie sters

        //        if (rows > 0)
        //            DisplayAlert("Success", "Item succesfully deleted", "Ok");
        //        else
        //            DisplayAlert("Failure", "Item failed to be deleted", "Ok");
        //    }
        //}

        //--------------------------------

    }
}