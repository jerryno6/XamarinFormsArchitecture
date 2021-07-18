using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsArchitecture.Shared.Core.Interfaces.DataClients;
using XamarinFormsArchitecture.Shared.Core.Interfaces.Repositories;
using XamarinFormsArchitecture.Shared.Core.Model;

namespace XamarinFormsArchitecture.Data.Repository
{
	public class GreetRepository : IGreetRepository
	{
		IGreetgRPCClient greetDataClient;

		public GreetRepository(IGreetgRPCClient greetgRPCClient)
		{
			greetDataClient = greetgRPCClient;
		}

		public async Task<Greet> Greet()
		{
			var result = await greetDataClient.GreetAsync();

			return result;
		}
	}
}
