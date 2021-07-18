using System;
using System.Collections.Generic;
using System.Text;

namespace FormsArchitecture.Data.gRPCClient
{
	public class BaseClient
	{
		private string _baseUrl;
		protected string BaseUrl => _baseUrl;

		public BaseClient(string baseUrl)
		{
			_baseUrl = baseUrl;
		}
	}
}
