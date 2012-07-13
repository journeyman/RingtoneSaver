using System.Windows.Controls;
using Microsoft.Phone.Controls;
using System.Windows;

namespace AudioControls
{
    [TemplatePart(Name = "RootCanvas", Type = typeof(Canvas))]
    [TemplatePart(Name = "CroppingMask", Type = typeof(FrameworkElement))]
	public class FileCutterControl : ContentControl
	{
        private Canvas RootCanvas { get; set; }
        private FrameworkElement CroppingMask { get; set; }

		public FileCutterControl()
		{
			DefaultStyleKey = typeof (FileCutterControl);
		}

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            RootCanvas = (Canvas)this.GetTemplateChild("RootCanvas");
            CroppingMask = (FrameworkElement)this.GetTemplateChild("CroppingMask");
            //this will create new GestureListener if not already created
            var gestureListener = GestureService.GetGestureListener(CroppingMask);
            gestureListener.DragDelta += OnDragDelta;
        }

        void OnDragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            SetXOffsetToCroppingMask(e.HorizontalChange);
        }

        private void SetXOffsetToCroppingMask(double xOffset)
        {
            double currentPosition = (double) CroppingMask.GetValue(Canvas.LeftProperty);
            double newPosition = currentPosition + xOffset;
            //checking the left bound
            if (newPosition < 0d)
            {
                CroppingMask.SetValue(Canvas.LeftProperty, 0d);
                return;
            }

            //checking right bound
            if (newPosition + CroppingMask.Width <= RootCanvas.ActualWidth)
            {
                //Cropping mask is in the center
                CroppingMask.SetValue(Canvas.LeftProperty, newPosition);
            }
            else
            {
                //right bound overlapped
                CroppingMask.SetValue(Canvas.LeftProperty, RootCanvas.ActualWidth - CroppingMask.Width);
            }

        }
	}
}
