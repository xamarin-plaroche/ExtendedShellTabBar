using CoreGraphics;
using ExtendedShellTabBar.Extensions.iOS;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace ExtendedShellTabBar.Renderers.iOS
{
    /*
      * ShellItemRenderer is UITabBarController
      * */
    public class ExtendedShellItemRenderer : ShellItemRenderer
    {
        IShellContext _context;

        public ExtendedShellItemRenderer(IShellContext context) : base(context)
        {
            _context = context;
        }

        public override async void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();

            if (ShellItem != null && ShellItem is VisualElements.ExtendedShellTabBar)
            {
                var tabbar = (VisualElements.ExtendedShellTabBar)ShellItem;

                var centeredTab = tabbar.CenteredTab;

                if (centeredTab != null && centeredTab.Icon != null)
                {
                    var x = (TabBar.Frame.Width - centeredTab.Width) / 2;
                    var y = TabBar.Frame.Y - centeredTab.Height / 2;
                    var imgView = new UIImageView(new CGRect(x, y, centeredTab.Width, centeredTab.Height));

                    var image = await centeredTab.Icon.GetNativeImageAsync();
                    imgView.Image = image;
                    imgView.ClipsToBounds = true;
                    imgView.Layer.CornerRadius = centeredTab.CornerRadius;
                    imgView.Layer.BorderColor = centeredTab.BorderColor.ToCGColor();
                    imgView.Layer.BorderWidth = centeredTab.BorderThickness;
                    imgView.UserInteractionEnabled = true;

                    if (centeredTab.Command != null)
                    {
                        imgView.AddGestureRecognizer(new UITapGestureRecognizer(TapGesture));
                    }

                    Add(imgView);
                }
            }
        }

        private void TapGesture()
        {
            var tabbar = (VisualElements.ExtendedShellTabBar)ShellItem;
            var centeredTab = tabbar.CenteredTab;
            centeredTab?.Command?.Execute(centeredTab);
        }
    }
}
