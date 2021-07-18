using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsArchitecture.Shared.Core.Interfaces.Repositories;

namespace FormsArchitecture.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private IGreetRepository repository;

		private string greetMessage;
		public string GreetMessage { get => greetMessage; set => SetProperty(ref greetMessage, value); }

		public MainViewModel(IGreetRepository greetRepository)
		{
			repository = greetRepository;

			LoadCommand = new AsyncRelayCommand(LoadAsync, () => !IsBusy);
		}

		private async Task LoadAsync()
		{
			GreetMessage = string.Empty;
			IsBusy = true;

			try
			{
				
				var result = await repository.Greet();
				GreetMessage = result.Message;

			}
			catch (Exception ex)
			{
				GreetMessage = $"ERROR {ex.Message}";
			}

			IsBusy = false;

		}
	}
}
