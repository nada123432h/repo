using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sa2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
       
            Task.Run(AnimateBorder);

        }
        private async void AnimateBorder()
        {
            Action<double> tealMovement = tInput => tealGrad.Offset = (float)tInput;
            Action<double> orangeMovement = oInput => orangeGrad.Offset = (float)oInput;

            while (true)

            {
                mainRect.Animate(name: "s",  tealMovement, start: 0, end: 1, length: 1000, easing: Easing.SinInOut);
                await Task.Delay(1000);
                mainRect.Animate(name: "s", tealMovement, start: 1, end: 0, length: 1000, easing: Easing.SinIn);
                await Task.Delay(1000);

                mainRect.Animate(name: "s",orangeMovement, start: 1, end: 0, length: 1000, easing: Easing.SinIn);
                await Task.Delay(1000);
                mainRect.Animate(name: "s",  orangeMovement, start: 0, end: 1, length: 1000, easing: Easing.SinIn);
                await Task.Delay(1000);
            }
        }
        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}