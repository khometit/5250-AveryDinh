using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mine.Views
{
    /// <summary>
    /// Code behind for GamePage
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Even handler for when the Game Button is clicked, show pop up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void GameButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("SU", "Go RedHawks", "OK");
        }
    }
}