using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsArchitecture.Shared.Core.Interfaces.DataClients;
using XamarinFormsArchitecture.Shared.Core.Model;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

namespace FormsArchitecture.Data.gRPCClient
{
	public class GreetgRPCClient : BaseClient, IGreetgRPCClient
	{
		public GreetgRPCClient() : base()
		{

		}

		public async Task<Greet> GreetAsync(string baseUrl)
		{
			var httpHandler = new HttpClientHandler();

#if DEBUG
			// Return `true` to allow certificates that are untrusted/invalid
			httpHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;
#endif

			using var channel = GrpcChannel.ForAddress(baseUrl, new GrpcChannelOptions
			{
				HttpHandler = new GrpcWebHandler(httpHandler)
			});
			var client = new Greeter.GreeterClient(channel);
			HelloReply reply = await client.SayHelloAsync(new HelloRequest { Name = "VuLe" });

			var result = new Greet()
			{
				Message = reply.Message
			};

			return result;
		}
	}
}
