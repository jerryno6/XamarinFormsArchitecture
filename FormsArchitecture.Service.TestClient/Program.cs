using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FormsArchitecture.Service.TestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                //Show menu
                Console.Clear();
                Console.WriteLine("0: exit");
                Console.WriteLine("1: run");
                string choise = Console.ReadLine();

                //Action
                switch (choise)
                {
                    case "0": 
                        return;

                    case "1":
                        await SayHello(); 
                        break;
                }

                //waiting for user's action
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }

        private static async Task SayHello()
        {
            try
            {
                var baseUrl = "https://localhost:5000";
                var result = await new GrpcClient().SayHello(baseUrl);
                Console.WriteLine(result);
                Debug.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
