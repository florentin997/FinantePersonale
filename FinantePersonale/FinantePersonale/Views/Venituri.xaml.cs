using Microcharts;
using SkiaSharp;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinantePersonale.Views;

namespace FinantePersonale.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Venituri : ContentPage
    {

        //trebuie sa il fac sa salveze categoria in tabela de categorii
       /* async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var categorie = (CategorieDB)BindingContext;
            categorie.DenumireCategorie = String.Empty;
            await App.Database.SaveCategorieAsync(categorie);
            await Navigation.PopAsync();
        }*/
        /*
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
        */

        private readonly ChartEntry[] entries = new[]
        {
            new ChartEntry(300)
            {
                Label = "Salariu",
                ValueLabelColor=SKColor.Parse("#2c3e50"),
                ValueLabel = "300",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(300)
            {
                Label = "Actiuni",
                ValueLabelColor=SKColor.Parse("#0328fc"),
                ValueLabel = "300",
                Color = SKColor.Parse("#0328fc")
            },
            new ChartEntry(150)
            {
                Label = "Dividende",
                ValueLabelColor=SKColor.Parse("#5d1885"),
                ValueLabel = "150",
                Color = SKColor.Parse("#5d1885")
            },
            new ChartEntry(250)
            {
                Label = "Chirii",
                ValueLabelColor=SKColor.Parse("#3498db"),
                ValueLabel = "250",
                Color = SKColor.Parse("#3498db")
            }
        };

        public Venituri()
        {
            InitializeComponent();

            charPieVenituri.Chart = new PieChart{
                Entries = entries,
                HoleRadius = 0.5f,
                LabelTextSize = 40,
                BackgroundColor = SKColors.Transparent,
            };
        }
        /*
        private void ToolbarItem_Clicked_Venituri(object sender, System.EventArgs e)
        {
            BalantaDB venituri = new BalantaDB()
            {
                Suma = decimal.Parse(EntrySuma.Text),                //TREBUIE CA SUMA CARE AJUNGE IN BD SA FIE DE TIP DECIMAL 
                Data = DateTime.Today.ToString()                    //NU SUNT SIGUR DACA ASA SE FACE AICI
            };

            SubcategorieDB subcategorie = new SubcategorieDB()
            {
                DenumireSubcategorie = EntrySubcategorie.Text.ToString()
            };

            SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);   //App.DatabaseLocation e pathul din App.xaml.cs care o obtine din Mainactivity 
            connection.CreateTable<BalantaDB>();

            //test daca insereaza datele
            int nrRanduri = connection.Insert(venituri);
            int nrRanduriInSubcateg= connection.Insert(subcategorie);
            
            connection.Close();
            if (nrRanduri > 0 && nrRanduriInSubcateg>0)
            {
                DisplayAlert("Adaugare date","Inregistrare efectuata cu succes!","Ok");
            }
            else
            {
                DisplayAlert("Adaugare date", "Datele nu au fost inregistrate", "Ok");
            }
        }*/
    }
}