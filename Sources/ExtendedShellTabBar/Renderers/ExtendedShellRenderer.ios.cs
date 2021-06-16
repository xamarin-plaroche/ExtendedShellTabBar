using ExtendedShellTabBar.Renderers.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Shell), typeof(ExtendedShellRenderer))]
namespace ExtendedShellTabBar.Renderers.iOS
{
    public class ExtendedShellRenderer : ShellRenderer
    {
        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
        {
            return new ExtendedShellItemRenderer(this) { ShellItem = item };
        }
    }
}
