using System.Windows.Input;
using ExtendedShellTabBar.Enums;
using Xamarin.Forms;

namespace ExtendedShellTabBar.VisualElements
{
    public class ExtendedShellCenteredTab : BindableObject
	{
		public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ExtendedShellCenteredTab), default(ICommand));

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(ImageSource), typeof(ExtendedShellCenteredTab), null);

		public ImageSource Icon
		{
			get { return (ImageSource)GetValue(IconProperty); }
			set { SetValue(IconProperty, value); }
		}

		public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(ExtendedShellCenteredTab), 0);

		public int CornerRadius
		{
			get { return (int)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}

		public static readonly BindableProperty BorderThicknessProperty = BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(ExtendedShellCenteredTab), 0);

		public int BorderThickness
		{
			get { return (int)GetValue(BorderThicknessProperty); }
			set { SetValue(BorderThicknessProperty, value); }
		}

		public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(ExtendedShellCenteredTab), Color.Transparent);

		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}

		public static readonly BindableProperty CornersTransformationProperty = BindableProperty.Create(nameof(CornersTransformation), typeof(CornerTransformType), typeof(ExtendedShellCenteredTab), CornerTransformType.AllRounded);

		public CornerTransformType CornersTransformation
		{
			get => (CornerTransformType)GetValue(CornersTransformationProperty);
			set => SetValue(CornersTransformationProperty, value);
		}

		public static readonly BindableProperty WidthProperty = BindableProperty.Create(nameof(Width), typeof(int), typeof(ExtendedShellCenteredTab), 0);

		public int Width
		{
			get { return (int)GetValue(WidthProperty); }
			set { SetValue(WidthProperty, value); }
		}

		public static readonly BindableProperty HeightProperty = BindableProperty.Create(nameof(Height), typeof(int), typeof(ExtendedShellCenteredTab), 0);

		public int Height
		{
			get { return (int)GetValue(HeightProperty); }
			set { SetValue(HeightProperty, value); }
		}
	}
}
