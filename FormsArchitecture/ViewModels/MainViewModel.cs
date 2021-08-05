using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FormsArchitecture.Configurations;
using XamarinFormsArchitecture.Shared.Core.Interfaces.Repositories;

namespace FormsArchitecture.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private IGreetRepository _repository;

		public string BaseUrl
		{
			get => AppConfig.BaseUrl;
			set => AppConfig.BaseUrl = value;
		}	
		private string greetMessage;
		public string GreetMessage { get => greetMessage; set => SetProperty(ref greetMessage, value); }

		public MainViewModel(IGreetRepository greetRepository)
		{
			_repository = greetRepository;

			LoadCommand = new AsyncRelayCommand(LoadAsync, () => !IsBusy);
		}

		private async Task LoadAsync()
		{
			GreetMessage = string.Empty;
			IsBusy = true;

			try
			{
				var result = await _repository.Greet(BaseUrl, "VuLe");
				GreetMessage =$"Successfully: {result.Message}";

			}
			catch (Exception ex)
			{
				GreetMessage = $"ERROR {ex.Message}";
			}

			IsBusy = false;

		}
	}
}
