using FinantePersonale.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FinantePersonale.ViewModels
{
    public class IstoricWishlistVM 
    {
        public ObservableCollection<ModelWishlist> IstWishlistItems
        {
            get;
            set;
        }

        public IstoricWishlistVM()
        {
            IstWishlistItems = new ObservableCollection<ModelWishlist>();
            GetWishlist();
        }

        private void GetWishlist()
        {
            var items = ModelWishlist.GetValue();

            IstWishlistItems.Clear();

            foreach (var item in items)
            {
                IstWishlistItems.Add(item);
            }
        }
    }
}

