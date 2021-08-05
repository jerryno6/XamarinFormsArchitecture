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

		public async Task<Greet> GreetAsync(string baseUrl, string name)
		{
#if DEBUG
			if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				// The following statement allows you to call insecure services. To be used only in development environments.
				AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
				baseUrl = baseUrl.Replace("https://","http://");
			}
#endif

			// The port number(5001) must match the port of the gRPC server.
			using var channel = GrpcChannel.ForAddress(baseUrl);
			var client = new Greeter.GreeterClient(channel);
			HelloReply reply = await client.SayHelloAsync(new HelloRequest {Name = "VuLe"});

			return new Greet() {Message = reply.Message};
		}
	}
}
