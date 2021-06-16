using System.ComponentModel;
using Xamarin.Forms;
using ExtendedShellTabBarSample.ViewModels;

namespace ExtendedShellTabBarSample.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}