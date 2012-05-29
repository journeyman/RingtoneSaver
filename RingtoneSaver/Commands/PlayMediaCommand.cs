using System;
using RingtoneSaver.Infrastructure.Media;
namespace RingtoneSaver.Commands
{
	public class PlayAudioCommand : CommandBase<string>
	{
		public override void Execute(string mediaUrl)
		{
			MediaService.PlayAudio(new Uri(mediaUrl, UriKind.RelativeOrAbsolute));
		}
	}
}
