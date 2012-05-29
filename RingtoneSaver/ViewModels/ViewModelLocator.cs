namespace RingtoneSaver.ViewModels
{
	public static class ViewModelLocator
	{
		private static MainViewModel mainViewModel;
		public static MainViewModel MainViewModel
		{
			get { return mainViewModel ?? (mainViewModel = new MainViewModel()); }
		}
	}
}
