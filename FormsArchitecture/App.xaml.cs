using FormsArchitecture.Configurations;
using FormsArchitecture.Data.gRPCClient;
using FormsArchitecture.Pages;
using FormsArchitecture.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsArchitecture.Data.Repository;
using XamarinFormsArchitecture.Shared.Core.Interfaces.DataClients;
using XamarinFormsArchitecture.Shared.Core.Interfaces.Repositories;

namespace FormsArchitecture
{
	public partial class App : Application
	{
		public App()
		{
			Services = ConfigureServices();

			InitializeComponent();

			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}

		/// <summary>
		/// Gets the current <see cref="App"/> instance in use
		/// </summary>
		public new static App Current => (App)Application.Current;

		/// <summary>
		/// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
		/// </summary>
		public IServiceProvider Services { get; }

		/// <summary>
		/// Configures the services for the application.
		/// </summary>
		private static IServiceProvider ConfigureServices()
		{
			var services = new ServiceCollection();

			//Add repository
			services.AddSingleton<IGreetRepository, GreetRepository>();

			//Add clients
			services.AddSingleton(typeof(IGreetgRPCClient), new GreetgRPCClient(AppConfig.BaseUrl));

			//Add ViewModelss
			services.AddTransient<MainViewModel>();

			return services.BuildServiceProvider();
		}
	}
}
