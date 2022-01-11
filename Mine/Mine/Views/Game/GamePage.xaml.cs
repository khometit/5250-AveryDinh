using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mine.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();
        }

        async void GameButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("SU", "Go RedHawks", "OK");
        }
    }
}