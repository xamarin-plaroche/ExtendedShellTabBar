using Android.Content;
using ExtendedShellTabBar.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Shell), typeof(ExtendedShellRenderer))]
namespace ExtendedShellTabBar.Renderers
{
    public class ExtendedShellRenderer : ShellRenderer
    {
        public ExtendedShellRenderer(Context context) : base(context)
        {
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            return new ExtendedShellItemRenderer(this);
        }
    }
}
