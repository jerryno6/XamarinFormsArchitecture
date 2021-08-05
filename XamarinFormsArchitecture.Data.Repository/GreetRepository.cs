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
		private readonly IGreetgRPCClient _greetDataClient;

		public GreetRepository(IGreetgRPCClient greetgRpcClient)
		{
			_greetDataClient = greetgRpcClient;
		}

		public async Task<Greet> Greet(string baseUrl, string name)
		{
			var result = await _greetDataClient.GreetAsync(baseUrl, name);

			return result;
		}
	}
}
