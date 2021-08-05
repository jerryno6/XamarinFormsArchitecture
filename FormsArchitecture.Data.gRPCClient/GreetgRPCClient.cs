using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
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
			//todo: only use this to run in MACOS as develop environment
			if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				// Return `true` to allow certificates that are untrusted/invalid
				httpHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;
			}
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
