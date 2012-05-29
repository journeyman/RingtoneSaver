using System.Windows;
using System.Windows.Controls;
using RingtoneSaver.Infrastructure.Media;

namespace RingtoneSaver.Infrastructure.Common
{
	public static class Bootstrapper
	{
		public static void InitApp()
		{
			var mediaElement = Application.Current.Resources["MediaElement"] as MediaElement;

			MediaService.Init(new MediaElementAudioPlayer(mediaElement));
		}
	}
}
