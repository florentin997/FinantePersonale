using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinantePersonale.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinantePersonale.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategorieView : ContentPage
    {
       // CategorieVM _viewModel;
        public CategorieView()
        {
            InitializeComponent();

            //BindingContext = _viewModel = new CategorieVM();
        }
    }
}