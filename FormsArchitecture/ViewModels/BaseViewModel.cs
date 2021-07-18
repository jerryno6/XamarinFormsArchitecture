using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormsArchitecture.ViewModels
{
	public class BaseViewModel : ObservableObject
	{
		public AsyncRelayCommand LoadCommand { get; set; }
		public AsyncRelayCommand RefreshCommand { get; set; }

		private bool isBusy;
		public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); }

		private bool isRefreshing;
		public bool IsRefreshing { get => isRefreshing; set => SetProperty(ref isRefreshing, value); }

		public BaseViewModel()
		{

		}

	}
}
