using FormsArchitecture.Shared.gRPC;
using Grpc.Net.Client;
using System.Threading.Tasks;

namespace FormsArchitecture.Service.TestClient
{
    public class GrpcClient
    {
        public async Task<string> SayHello(string baseUrl)
        {
            baseUrl ??= "https://localhost:5000";

            using var channel = GrpcChannel.ForAddress(baseUrl);
            var client = new Greeter.GreeterClient(channel);
            HelloReply reply = await client.SayHelloAsync(new HelloRequest { Name = "VuLe" });

            return reply.Message;
        }
    }
}
