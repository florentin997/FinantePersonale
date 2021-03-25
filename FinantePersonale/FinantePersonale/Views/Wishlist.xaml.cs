
using FinantePersonale.Models;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data;
using System.Data.SqlTypes;

namespace FinantePersonale.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Wishlist : ContentPage
    {

        public Wishlist()
        {
            InitializeComponent();

        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var selectedItem = itemListView.SelectedItem as ModelWishlist;
        //}

        //public static int GetIdObiectselectat()
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
        //    {
        //        conn.CreateTable<ModelWishlist>();
        //        return ;
        //    }
        //}


        public void deleteButtonWishlist_Clicked(object sender, System.EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<ModelWishlist>();
                int rows = conn.Delete(Id);    //cred ca imi trebuie o metoda pentru a returna ID-ul obiectului

                if (rows > 0)
                    DisplayAlert("Success", "Experience succesfully deleted", "Ok");
                else
                    DisplayAlert("Failure", "Experience failed to be deleted", "Ok");
            }
        }
    }
}