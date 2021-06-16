using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Graphics.Drawable;
using ExtendedShellTabBar.Controls.Droid;
using ExtendedShellTabBar.Extensions.Droid;
using Google.Android.Material.BottomNavigation;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

namespace ExtendedShellTabBar.Renderers
{
    public class ExtendedShellItemRenderer : ShellItemRenderer
    {
        IShellContext _context;

        FrameLayout _mainLayout;

        FrameLayout _bottomView;

        View _outerLayout;

        ExtendedButton button;

        public ExtendedShellItemRenderer(IShellContext shellContext) : base(shellContext)
        {
            _context = shellContext;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _outerLayout = base.OnCreateView(inflater, container, savedInstanceState);
            _bottomView = _outerLayout.FindViewById<BottomNavigationView>(Resource.Id.bottomtab_tabbar);

            _mainLayout = new FrameLayout(Context);

            var lp = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent);
            _mainLayout.LayoutParameters = lp;

            _mainLayout.AddView(_outerLayout);

            if (ShellItem != null && ShellItem is VisualElements.ExtendedShellTabBar)
                {
                var tabbar = (VisualElements.ExtendedShellTabBar)ShellItem;

                var centeredTab = tabbar.CenteredTab;

                if (centeredTab != null && centeredTab.Icon != null)
                {

                    SetupLargeTab();
                }
            }

            _mainLayout.ForceLayout();

            return _mainLayout;
        }

        private async void SetupLargeTab()
        {
            if (ShellItem != null)
            {

                var centeredLayout = new FrameLayout(Context);

                var tabbar = (VisualElements.ExtendedShellTabBar)ShellItem;
                var centeredTab = tabbar.CenteredTab;

                var bitmap = await centeredTab.Icon.GetNativeImageAsync(this.Context);

                button = new ExtendedButton(Context)
                {
                    CornerRadius = centeredTab.CornerRadius * Resources.DisplayMetrics.Density,
                    BorderColor = centeredTab.BorderColor.ToAndroid(),
                    BorderThickness = centeredTab.BorderThickness
                };

                var lp = new LinearLayout.LayoutParams((int)(centeredTab.Width * Resources.DisplayMetrics.Density), (int)(centeredTab.Height * Resources.DisplayMetrics.Density));
                button.LayoutParameters = lp;

                // -- Remove Shadows
                button.StateListAnimator = null;

                var drawable = RoundedBitmapDrawableFactory.Create(Resources, bitmap);
                drawable.CornerRadius = centeredTab.CornerRadius * Resources.DisplayMetrics.Density;
                button.Background = drawable;

                centeredLayout.AddView(button);

                button.Click += Image_Click;

                var flp = new FrameLayout.LayoutParams(FrameLayout.LayoutParams.WrapContent, FrameLayout.LayoutParams.WrapContent, GravityFlags.CenterHorizontal | GravityFlags.Bottom);
                flp.BottomMargin = _bottomView.MeasuredHeight / 2;

                centeredLayout.LayoutParameters = flp;

                _mainLayout.AddView(centeredLayout);

                _mainLayout.ForceLayout();

            }
        }

        private void Image_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Click !");
            if (ShellItem != null)
            {
                var tabbar = (VisualElements.ExtendedShellTabBar)ShellItem;
                var centeredTab = tabbar.CenteredTab;
                centeredTab.Command?.Execute(centeredTab);
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            button.Click -= Image_Click;
        }
    }
}
