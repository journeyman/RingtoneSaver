using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace AudioControls
{
    [TemplatePart(Name = LEFT_BORDER_NAME, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = RIGHT_BORDER_NAME, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = ROOT_PANEL_NAME, Type = typeof(Canvas))]
    public class CroppingMask : Control
    {
        public const string LEFT_BORDER_NAME = "LeftBorder";
        public const string RIGHT_BORDER_NAME = "RightBorder";
        public const string ROOT_PANEL_NAME = "RootPanel";

        private FrameworkElement LeftBorder { get; set; }
        private FrameworkElement RightBorder { get; set; }
        private FrameworkElement RootCanvas { get; set; }

        public CroppingMask()
        {
            DefaultStyleKey = typeof (CroppingMask);
        }

        public event EventHandler<DragDeltaGestureEventArgs> LeftBorderDragged = delegate { };
        public event EventHandler<DragDeltaGestureEventArgs> RightBorderDragged = delegate { };
        public event EventHandler<DragDeltaGestureEventArgs> Dragged = delegate { };

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.LeftBorder = this.GetTemplateChild(LEFT_BORDER_NAME) as FrameworkElement;
            this.RightBorder = this.GetTemplateChild(RIGHT_BORDER_NAME) as FrameworkElement;
            this.RootCanvas = this.GetTemplateChild(ROOT_PANEL_NAME) as Canvas;

            this.LayoutUpdated += CroppingMask_LayoutUpdated;

            AlignBorders();
            
            //this will create new GestureListeners if not yet created
            GestureService.GetGestureListener(this.LeftBorder).DragDelta += OnLeftBorderDragged;
            GestureService.GetGestureListener(this.RightBorder).DragDelta += OnRightBorderDragged;
            GestureService.GetGestureListener(this.RootCanvas).DragDelta += OnRootCanvasDragged;
        }
        void CroppingMask_LayoutUpdated(object sender, EventArgs e)
        {
            AlignBorders();
        }

        private void AlignBorders()
        {
            //Alligning borders to left and right sides of Canvas
            Canvas.SetLeft(this.LeftBorder, -this.LeftBorder.Margin.Left);
            Canvas.SetLeft(this.RightBorder, this.RootCanvas.Width - this.RightBorder.Margin.Right - this.RightBorder.Width);
        }

        private void OnLeftBorderDragged(object sender, DragDeltaGestureEventArgs args)
        {
            args.Handled = true;
            this.LeftBorderDragged(this, args);
        }

        private void OnRightBorderDragged(object sender, DragDeltaGestureEventArgs args)
        {
            args.Handled = true;
            this.RightBorderDragged(this, args);
        }

        private void OnRootCanvasDragged(object sender, DragDeltaGestureEventArgs dragDeltaGestureEventArgs)
        {
            this.Dragged(this, dragDeltaGestureEventArgs);
        }
    }
}
