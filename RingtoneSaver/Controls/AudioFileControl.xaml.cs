using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace RingtoneSaver.Controls
{
	public partial class AudioFileControl : UserControl
	{
		public AudioFileControl()
		{
			InitializeComponent();

			((FrameworkElement)FindName("LayoutRoot")).DataContext = this;
		}

		private const string TitlePropertyName = "Title";
		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); } 
		}

		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
			TitlePropertyName,
			typeof(string),
			typeof(AudioFileControl),
			new PropertyMetadata(null));

		private const string FileUrlPropertyName = "FileUrl";
		public string FileUrl
		{
			get { return (string)GetValue(FileUrlProperty); }
			set { SetValue(FileUrlProperty, value); }
		}

		public static readonly DependencyProperty FileUrlProperty = DependencyProperty.Register(
			FileUrlPropertyName,
			typeof(string),
			typeof(AudioFileControl),
			new PropertyMetadata(null));


		public ICommand PlayAudioCommand
		{
			get { return (ICommand)GetValue(PlayAudioCommandProperty); }
			set { SetValue(PlayAudioCommandProperty, value); }
		}

		public static readonly DependencyProperty PlayAudioCommandProperty =
			DependencyProperty.Register("PlayAudioCommand", typeof(ICommand), typeof(AudioFileControl), new PropertyMetadata(null));



        public ICommand SaveRingtoneCommand
        {
            get { return (ICommand)GetValue(SaveRingtoneCommandProperty); }
            set { SetValue(SaveRingtoneCommandProperty, value); }
        }

        public static readonly DependencyProperty SaveRingtoneCommandProperty =
            DependencyProperty.Register("SaveRingtoneCommand", typeof(ICommand), typeof(AudioFileControl), new PropertyMetadata(null));
	}
}
