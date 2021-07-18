using FormsArchitecture.Data.gRPCClient;
using FormsArchitecture.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsArchitecture.Data.Repository;
using XamarinFormsArchitecture.Shared.Core.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FormsArchitecture.Pages
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BindingContext = App.Current.Services.GetService<MainViewModel>();
		}
	}
}
