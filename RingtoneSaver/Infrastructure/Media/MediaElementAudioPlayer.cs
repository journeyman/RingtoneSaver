using System.Windows.Controls;
using System.Windows.Media;
namespace RingtoneSaver.Infrastructure.Media
{
	public class MediaElementAudioPlayer : IAudioPlayer
	{
		private readonly MediaElement mediaElement;

		public MediaElementAudioPlayer(MediaElement mediaElement)
		{
			this.mediaElement = mediaElement;
		}

		public void PlayAudio(System.Uri uri)
		{
			if (mediaElement.Source == uri)
			{
                if (mediaElement.CurrentState == MediaElementState.Playing)
                    mediaElement.Pause();
                else
                    mediaElement.Play();
			}
			else
			{
				mediaElement.Source = uri;
			}
			var d = mediaElement.NaturalDuration;
		}
	}
}
