using FinantePersonale.ViewModels;
using FinantePersonale.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FinantePersonale
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Cheltuieli), typeof(Cheltuieli));
            Routing.RegisterRoute(nameof(Venituri), typeof(Venituri));
        }


    }
}
