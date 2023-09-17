using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sa2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.animationView.IsVisible = false;
            // this.animationView2.IsVisible = false;
            // this.loginButton.Clicked += loginButton_Clicked_1;

        }



        async private void loginButton_Clicked_1(object sender, EventArgs e)
        {
            this.animationView.IsVisible = true;
            await loginButton.ScaleTo(1.3, 250);
            await loginButton.ScaleTo(1.0, 250);
            // Delay for 3 seconds
            await Task.Delay(2000);

            // Hide the loading animation
            this.animationView.IsVisible = false;

            // Navigate to the next page (e.g., HomePage)
            await Navigation.PushAsync(new Views.HomePage());

        }

        async private void snakeEntry_Focused(object sender, FocusEventArgs e)
        {
            await emimg.ScaleTo(1.6, 250);

            //  this.animationView2.IsVisible = true;
        }

        async private void snakeEntry_Unfocused(object sender, FocusEventArgs e)
        {
            await emimg.ScaleTo(1.0, 250);
        }

        async private void Entry_Focused(object sender, FocusEventArgs e)
        {
            // await emimg2.RotateTo(360, 1000);
            await emimg2.ScaleTo(1.6, 250);
        }

        async private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            //  await emimg2.RotateTo(0, 0);
            await emimg2.ScaleTo(1.0, 250);
        }
    }
}

