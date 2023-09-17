using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using sa2.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sa2.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MenuItems = GetMenus();
            this.BindingContext = this;
        }

        public ObservableCollection<Menu> MenuItems { get; set; }


        private ObservableCollection<Menu> GetMenus()
        {
            return new ObservableCollection<Menu>
            {
                new Menu { Title = "PROFILE", Icon = "profile.png" },
                new Menu { Title = "FEED", Icon = "feed.png" },
                new Menu { Title = "ACTIVITY", Icon = "activity.png" },
                new Menu { Title = "SETTINGS", Icon = "settings.png" }
            };
        }

        private async void Show()
        {
            _ = TitleTxt.FadeTo(0);
            _ = MenuItemsView.FadeTo(1);
            await MainMenuView.RotateTo(0, 300, Easing.BounceOut);
        }

        private async void Hide()
        {
            _ = TitleTxt.FadeTo(1);
            _ = MenuItemsView.FadeTo(0);
            await MainMenuView.RotateTo(-90, 300, Easing.BounceOut);
        }

        private void ShowMenu(object sender, EventArgs e)
        {
            Show();
        }

      private async void MenuTapped(object sender, EventArgs e)
{
    string selectedTitle = ((sender as StackLayout).BindingContext as Menu).Title;
            string selectedIcon= ((sender as StackLayout).BindingContext as Menu).Icon;
            // TitleTxt.Text = selectedTitle;
            //  var detailsViewModel = new DetailsPageViewModel { Title = selectedTitle };
            var page = new Views.DetailsPage();

           // await Navigation.PushAsync(new Views.DetailsPage());
            DetailsPageViewModel oItemDetailsViewModel = new DetailsPageViewModel();
            oItemDetailsViewModel.Title = selectedTitle;
            oItemDetailsViewModel.Icon = selectedIcon;
            page.BindingContext = oItemDetailsViewModel;
            await App.Current.MainPage.Navigation.PushAsync(page);
            // await Application.Current.MainPage.Navigation.PushAsync(new DetailsPage { BindingContext = sa2.ViewModels.DetailsPageViewModel });

            Hide();
}

    }

    public class Menu
    {
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
