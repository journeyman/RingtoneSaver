using System.Windows;
using System.Windows.Controls;

namespace AudioControls
{
	public class UniformStackPanel : Panel
	{
		protected override Size MeasureOverride(Size availableSize)
		{
			double widthPerChild = Orientation == Orientation.Horizontal
			                       	? availableSize.Width/Children.Count
			                       	: availableSize.Width;

			double heightPerChild = Orientation == Orientation.Horizontal
			                        	? availableSize.Height
			                        	: availableSize.Height/Children.Count;


			double measuredWidth = 0;
			double measuredHeight = 0;
			foreach (UIElement child in Children)
			{
				child.Measure(new Size(widthPerChild, heightPerChild));
				//measuredWidth += child.DesiredSize.Width > widthPerChild ? widthPerChild : child.
			}
			return new Size();
		}

		public Orientation Orientation
		{
			get { return (Orientation)GetValue(OrientationProperty); }
			set { SetValue(OrientationProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Orientation.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty OrientationProperty =
			DependencyProperty.Register("Orientation", typeof(Orientation), typeof(UniformStackPanel), new PropertyMetadata(Orientation.Vertical));
	}
}
