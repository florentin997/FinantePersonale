using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FinantePersonale.Views;

namespace FinantePersonale.Views
{
    public partial class MainPage : TabbedPage
    {

        public MainPage()
        {
            InitializeComponent();
        }


        private void IstoricVen_ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new IstoricVenituri());
        }

        private void IstoricCh_ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new IstoricCheltuieli());
        }
    }
}
