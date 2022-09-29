using EnglishLearningApp.Stores;
using EnglishLearningApp.ViewModels;
using System.Windows;

namespace EnglishLearningApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly NavigationStore _navigationStore;

		public App()
		{
			_navigationStore = new NavigationStore();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			_navigationStore.CurrentViewModel = new StartupViewModel(_navigationStore);

			MainWindow = new MainWindow()
			{
				DataContext = new MainViewModel(_navigationStore)
			};
			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}
