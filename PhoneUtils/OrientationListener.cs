using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PhoneUtils
{
    public class OrientationListener
    {
        public OrientationListener()
        {
            var frame = Application.Current.RootVisual as PhoneApplicationFrame;
            if (frame != null)
                frame.OrientationChanged += frame_OrientationChanged;
        }

        void frame_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            bool isPortrait = (e.Orientation & PageOrientation.Portrait) == PageOrientation.Portrait;
            OnOrientationChanged(isPortrait ? Orientation.Vertical : Orientation.Horizontal);
        }

        private void OnOrientationChanged(Orientation orientation)
        {
            var handler = OrientationChanged;
            if (handler != null)
            {
                handler(orientation);
            }
        }

        public event Action<Orientation> OrientationChanged;
    }
}
