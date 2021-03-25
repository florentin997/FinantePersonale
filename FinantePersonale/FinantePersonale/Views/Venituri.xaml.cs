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
                //HoleRadius = 0.5f,
                LabelTextSize = 40,
                BackgroundColor = SKColors.Transparent,
            };
        }
    }
}