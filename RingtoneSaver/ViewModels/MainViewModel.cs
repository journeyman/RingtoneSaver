using System.Windows.Input;
using RingtoneSaver.Commands;

namespace RingtoneSaver.ViewModels
{
	public class MainViewModel
	{
		private readonly ICommand playAudioCommand;
        private readonly ICommand saveRingtoneCommand;

		public MainViewModel()
		{
			playAudioCommand = new PlayAudioCommand();
            saveRingtoneCommand = new SaveRingtoneCommand();
		}

		public ICommand PlayAudioCommand
		{
			get { return playAudioCommand; }
		}

        public ICommand SaveRingtoneCommand
        {
            get { return saveRingtoneCommand; }
        }
	}
}
