using System;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using System.Windows;

namespace AudioControls
{
    [TemplatePart(Name = ROOT_CANVAS_NAME, Type = typeof(Canvas))]
    [TemplatePart(Name = CROPPING_MASK_NAME, Type = typeof(CroppingMask))]
	public class FileCutterControl : ContentControl
	{
        public const string CROPPING_MASK_NAME = "CroppingMask";
        public const string ROOT_CANVAS_NAME = "RootCanvas";

        public static readonly DependencyProperty FileToCutProperty = DependencyProperty.Register("FileToCut", typeof(IFile), typeof(FileCutterControl), new PropertyMetadata(null, OnFileToCutChanged));
        public static readonly DependencyProperty MaxFileLengthProperty = DependencyProperty.Register("MaxFileLength", typeof(int), typeof(FileCutterControl), new PropertyMetadata(null));

        private Canvas RootCanvas { get; set; }
        private CroppingMask CroppingMask { get; set; }

		public FileCutterControl()
		{
			DefaultStyleKey = typeof (FileCutterControl);
		}

        /// <summary>
        /// Specified in bytes, max length of file that will remain after cropping
        /// </summary>
        public int? MaxFileLength
        {
            get { return (int?)GetValue(MaxFileLengthProperty); }
            set { SetValue(MaxFileLengthProperty, value); }
        }

        public IFile FileToCut
        {
            get { return (IFile)GetValue(FileToCutProperty); }
            set { SetValue(FileToCutProperty, value); }
        }


        private static void OnFileToCutChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            //TODO:Implement            
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.RootCanvas = (Canvas)this.GetTemplateChild(ROOT_CANVAS_NAME);
            this.CroppingMask = (CroppingMask)this.GetTemplateChild(CROPPING_MASK_NAME);

            this.CroppingMask.Dragged += OnEntireMaskDragged;
            this.CroppingMask.LeftBorderDragged += OnLeftBorderDragged;
            this.CroppingMask.RightBorderDragged += OnRightBorderDragged;
        }

        void OnEntireMaskDragged(object sender, DragDeltaGestureEventArgs e)
        {
            this.CroppingMaskOffsetX += e.HorizontalChange;
        }

        void OnLeftBorderDragged(object sender, DragDeltaGestureEventArgs e)
        {
            double delta = e.HorizontalChange;
            
            //if dragged to the left
            if (delta < 0d)
            {
                var offsetWithDelta = this.CroppingMaskOffsetX + delta;
                offsetWithDelta = offsetWithDelta < 0d ? 0d : offsetWithDelta;//checking left boundary
                
                //Adding left border offset to CroppingMask's width and adjusting offset
                var widthDelta = this.CroppingMaskOffsetX - offsetWithDelta;
                var validWidthDelta = this.AdjustWidthDeltaToConformLimits(widthDelta);
                CroppingMask.Width += widthDelta;
                this.CroppingMaskOffsetX += validWidthDelta;
            }
            else //dragged to the right
            {
                if (CroppingMask.Width - delta > 0)
                {
                    CroppingMask.Width -= delta;
                    CroppingMaskOffsetX += delta;
                }
            }
        }

        private double AdjustWidthDeltaToConformLimits(double widthDelta)
        {
            //TODO:calculate depending on File's Length and MaxFileLength
            return widthDelta;
        }

        void OnRightBorderDragged(object sender, DragDeltaGestureEventArgs e)
        {
            var change = e.HorizontalChange;

            //if dragged to the left
            if (change < 0d)
            {
                if (CroppingMask.Width + change >= CroppingMask.MinWidth)
                {
                    CroppingMask.Width += change;
                }
                else
                {
                    CroppingMask.Width = CroppingMask.MinWidth;
                }
            }
            else
            {
                if (RootCanvas.ActualWidth - CroppingMaskOffsetX - CroppingMask.Width - change > 0d)
                {
                    CroppingMask.Width += change;
                }
                else
                {
                    CroppingMask.Width += RootCanvas.ActualWidth - CroppingMask.Width - CroppingMaskOffsetX;
                }
            }
        }

        public double CroppingMaskOffsetX
        {
            get { return (double)CroppingMask.GetValue(Canvas.LeftProperty); }
            set
            {
                //checking the left bound
                if (value <= 0d)
                {
                    CroppingMask.SetValue(Canvas.LeftProperty, 0d);
                    return;
                }

                //checking right bound
                if (value + CroppingMask.Width <= RootCanvas.ActualWidth)
                {
                    //Cropping mask is in the center
                    CroppingMask.SetValue(Canvas.LeftProperty, value);
                }
                else
                {
                    //right bound overlapped
                    CroppingMask.SetValue(Canvas.LeftProperty, RootCanvas.ActualWidth - CroppingMask.Width);
                }
            }
        }
	}
}
