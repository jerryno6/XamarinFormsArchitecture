using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsArchitecture.Shared.Core.Model;

namespace XamarinFormsArchitecture.Shared.Core.Interfaces.DataClients
{
	public interface IGreetgRPCClient
	{
		Task<Greet> GreetAsync(string baseUrl, string name);
	}
}
