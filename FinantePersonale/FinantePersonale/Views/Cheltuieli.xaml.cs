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
    public partial class Cheltuieli : ContentPage
    {
        //SQLiteConnection conn = new SQLiteConnection(App.DatabasePath);

        //ChartEntry entry = new ChartEntry(float.Parse(viewModel.Item.label1))
        //{
        //    Label = singleEntry.Label,
        //    ValueLabel = viewModel.Item.label1,
        //    Color = singleEntry.Color
        //};

        private readonly ChartEntry[] entries = new[]
       {
            new ChartEntry(150) //valoarea din chart
            {
                Label = "Haine",     //categoria
                ValueLabelColor=SKColor.Parse("#2c3e50"),
                ValueLabel = "112", //valoarea care apare sub categorie
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(150)
            {
                Label = "Divertisment",
                ValueLabelColor=SKColor.Parse("#77d065"),
                ValueLabel = "648",
                Color = SKColor.Parse("#77d065")
            },
            new ChartEntry(600)
            {
                Label = "Mancare",
                ValueLabelColor=SKColor.Parse("#0328fc"),
                ValueLabel = "428",
                Color = SKColor.Parse("#0328fc")
            },
            new ChartEntry(100)
            {
                Label = "Transport",
                ValueLabelColor=SKColor.Parse("#5d1885"),
                ValueLabel = "214",
                Color = SKColor.Parse("#5d1885")
            }
        };

        //internal static object GetCheltuieliS()
        //{
        //    throw new NotImplementedException();
        //}

        public Cheltuieli()
        {
            InitializeComponent();

            charPieCheltuieli.Chart = new PieChart {
                Entries = entries,
                //HoleRadius = 0.5f,
                LabelTextSize = 40,
                BackgroundColor = SKColors.Transparent,
                //Typeface=SKTypeface.Default   //nu schimba nimic
            };
          

        }

    }
}