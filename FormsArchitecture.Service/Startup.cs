using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FormsArchitecture.Service
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddGrpc();

			//services.AddAuthorization();
			//services.AddAuthentication();

			services.AddCors(o => o.AddPolicy("AllowAll", builder =>
			{
				builder.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()
				.WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
			}));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			//app.UseAuthorization();
			//app.UseAuthentication();

			app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });// Must be added between UseRouting and UseEndpoints
			app.UseCors();

			// Add after existing UseGrpcWeb to fix for 3.1
			//https://github.com/grpc/grpc-dotnet/issues/853#issuecomment-610078202
			app.Use((c, next) =>
			{
				if (c.Request.ContentType == "application/grpc")
				{
					var current = c.Features.Get<IHttpResponseFeature>();
					c.Features.Set<IHttpResponseFeature>(new HttpSysWorkaroundHttpResponseFeature(current));
				}
				return next();
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<GreeterService>().RequireCors("AllowAll");

				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
				});
			});
		}
	}
}
