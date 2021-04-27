using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinantePersonale.Views;
namespace FinantePersonale
{
    public partial class App : Application
    {
        public static string DatabasePath;

        //public App()
        //{
        //    InitializeComponent();

        //    MainPage = new NavigationPage(new MainPage());
        //}

        public App(string databasePath)
        {
            InitializeComponent();

            DatabasePath = databasePath;

            //MainPage = new NavigationPage(new MainPage());
            MainPage = new AppShell();
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
