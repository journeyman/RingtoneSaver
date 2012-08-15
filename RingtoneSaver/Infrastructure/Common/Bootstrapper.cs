using System.Windows;
using System.Windows.Controls;
using RingtoneSaver.Infrastructure.Media;

namespace RingtoneSaver.Infrastructure.Common
{
	public static class Bootstrapper
	{
		public static void InitApp()
		{
			MediaService.Init(new MediaElementAudioPlayer(new MediaElement()));
		}
	}
}
