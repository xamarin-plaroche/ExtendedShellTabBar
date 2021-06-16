using Xamarin.Forms;

namespace ExtendedShellTabBar.VisualElements
{
    public class ExtendedShellTabBar : TabBar
    {
        public static readonly BindableProperty CenteredTabProperty = BindableProperty.Create(nameof(CenteredTab), typeof(ExtendedShellCenteredTab), typeof(ExtendedShellTabBar), default(ExtendedShellCenteredTab));

        public ExtendedShellCenteredTab CenteredTab
        {
            get { return (ExtendedShellCenteredTab)GetValue(CenteredTabProperty); }
            set { SetValue(CenteredTabProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            CenteredTab.BindingContext = this.BindingContext;
        }
    }
}
