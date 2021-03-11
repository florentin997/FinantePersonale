
using FinantePersonale.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinantePersonale.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Wishlist : ContentPage
    {
        public Wishlist()
        {
            InitializeComponent();
        }


        //aici incercam sa sterg obiectul pe care apas
        private void WishlistTextCell_Tapped(object sender, System.EventArgs e)
        {
            List<ModelWishlist> tappedItem = new List<ModelWishlist>();

        }
    }
}