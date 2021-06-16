using System;
using System.Collections.Generic;
using ExtendedShellTabBarSample.ViewModels;
using ExtendedShellTabBarSample.Views;
using Xamarin.Forms;

namespace ExtendedShellTabBarSample
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            this.BindingContext = new AppShellViewModel();

            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }
    }
}
