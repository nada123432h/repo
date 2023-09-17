using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace sa2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Menu> _menuItems;
        private double _titleTxtOpacity;
        private double _menuItemsViewOpacity;
        private double _mainMenuViewRotation;

        public MainViewModel()
        {
            MenuItems = GetMenus();
            TitleTxtOpacity = 1;
            MenuItemsViewOpacity = 0;
            MainMenuViewRotation = -90;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Menu> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        public double TitleTxtOpacity
        {
            get => _titleTxtOpacity;
            set
            {
                _titleTxtOpacity = value;
                OnPropertyChanged();
            }
        }

        public double MenuItemsViewOpacity
        {
            get => _menuItemsViewOpacity;
            set
            {
                _menuItemsViewOpacity = value;
                OnPropertyChanged();
            }
        }

        public double MainMenuViewRotation
        {
            get => _mainMenuViewRotation;
            set
            {
                _mainMenuViewRotation = value;
                OnPropertyChanged();
            }
        }

        public void Show()
        {
            TitleTxtOpacity = 0;
            MenuItemsViewOpacity = 1;
            MainMenuViewRotation = 0;
        }

        public void Hide()
        {
            TitleTxtOpacity = 1;
            MenuItemsViewOpacity = 0;
            MainMenuViewRotation = -90;
        }

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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Menu
    {
        public string Title { get; set; }
        public string Icon { get; set; }
    }

}
