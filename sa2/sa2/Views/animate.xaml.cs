using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sa2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class animate : ContentPage
    {
        public animate()
        {
            InitializeComponent();
            Budgets = GetBudgets();
            this.BindingContext = this;

        }

        private ObservableCollection<Budget> budgets;
        public ObservableCollection<Budget> Budgets
        {
            get { return budgets; }
            set
            {
                budgets = value;
                OnPropertyChanged();
            }
        }
        private float _SelectedAmount;
        public float SelectedAmount
        {
            get { return _SelectedAmount; }
            set
            {
                _SelectedAmount = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Budget> GetBudgets()
        {
            return new ObservableCollection<Budget>
            {
                new Budget { Name = "Food", Amount = 650, Color = Color.Blue, Image = "food.png" },
                new Budget { Name = "Groceries", Amount = 1350, Color = Color.SlateBlue, Image = "grocery.png" },
                new Budget { Name = "Transport", Amount = 170, Color = Color.Purple, Image = "transport.png" },
                new Budget { Name = "Utilities", Amount = 750, Color = Color.PeachPuff, Image = "utilities.png" },
            };
        }

        private int clickCount = 0;

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var grid = sender as Grid;
            var parent = grid.Parent as CollectionView;
            var selectionBg = grid.FindByName<BoxView>("MainBg");
            var selectionDetails = grid.FindByName<StackLayout>("DetailsView");
           

            clickCount++;

            if (clickCount == 2)
            {
            
                selectionDetails.TranslateTo(-50, 0, 200, Easing.BounceIn);
                selectionBg.IsVisible = false;
                selectionDetails.IsVisible = false;

                clickCount = 0;
            }
            else if (clickCount == 1)
            {
                var selectedItem = grid.BindingContext as Budget;

                animated(selectedItem.Amount);
                // تنفيذ السطور عند الضغط للمرة الأولى (تحديد العنصر)
                selectionBg.IsVisible = true;
                selectionDetails.IsVisible = true;
                selectionDetails.TranslateTo(0, 0, 300, Easing.SinInOut);
            }
       

        }
        public void animated (float amount)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(2.5), () =>
            {
                double t = stopwatch.Elapsed.TotalSeconds;
                SelectedAmount = Math.Min((float)amount, SelectedAmount + (float)(100 * t));
                if (amount <= SelectedAmount)
                {
                    stopwatch.Stop();
                    return false;
                }
                return true;
            });




        }
    }
    public class Budget
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public float Amount { get; set; }
        public Color Color { get; set; }
    }

}

