﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace Expression.Blend.SampleData.SampleDropboxLoginViewModel
{
	using System; 

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
	internal class SampleDropboxLoginViewModel { }
#else

	public class SampleDropboxLoginViewModel : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		public SampleDropboxLoginViewModel()
		{
			try
			{
				System.Uri resourceUri = new System.Uri("/RingtoneSaver;component/SampleData/SampleDropboxLoginViewModel/SampleDropboxLoginViewModel.xaml", System.UriKind.Relative);
				if (System.Windows.Application.GetResourceStream(resourceUri) != null)
				{
					System.Windows.Application.LoadComponent(this, resourceUri);
				}
			}
			catch (System.Exception)
			{
			}
		}

		private string _Login = string.Empty;

		public string Login
		{
			get
			{
				return this._Login;
			}

			set
			{
				if (this._Login != value)
				{
					this._Login = value;
					this.OnPropertyChanged("Login");
				}
			}
		}

		private string _Password = string.Empty;

		public string Password
		{
			get
			{
				return this._Password;
			}

			set
			{
				if (this._Password != value)
				{
					this._Password = value;
					this.OnPropertyChanged("Password");
				}
			}
		}

		private bool _IsBusy = false;

		public bool IsBusy
		{
			get
			{
				return this._IsBusy;
			}

			set
			{
				if (this._IsBusy != value)
				{
					this._IsBusy = value;
					this.OnPropertyChanged("IsBusy");
				}
			}
		}
	}
#endif
}