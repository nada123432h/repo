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
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }
        public DetailsPage(string title,string icon)
        {
            InitializeComponent();
            TitleTxt.Text = title;
            Icon.Source = icon;
        }

    
    }
}