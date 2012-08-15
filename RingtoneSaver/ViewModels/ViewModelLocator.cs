namespace RingtoneSaver.ViewModels
{
	public static class ViewModelLocator
	{
		private static MainViewModel _mainViewModel;
		public static MainViewModel MainViewModel
		{
			get { return _mainViewModel ?? (_mainViewModel = new MainViewModel()); }
		}
	}
}
