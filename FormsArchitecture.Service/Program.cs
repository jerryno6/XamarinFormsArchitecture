using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace FormsArchitecture.Service
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		// Additional configuration is required to successfully run gRPC on macOS.
		// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();


// #if DEBUG
// 					//todo: only use this to run in MACOS as develop environment
// 					webBuilder.ConfigureKestrel(options =>
// 					{
// 						options.Limits.MinRequestBodyDataRate = null;

// 						options.ListenAnyIP(35960,
// 							listenOptions => { listenOptions.Protocols = HttpProtocols.Http2; });
// 					});
// #endif
				});
	}
}
