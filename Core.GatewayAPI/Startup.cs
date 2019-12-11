using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.GatewayAPI.Services;
using Core.GatewayAPI.Services.Contracts;
using Herald;
using Herald.Contracts;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core.GatewayAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IUsersService, UsersService>();
			services.AddTransient<IAuthenticator, Authenticator>();

			services.AddHerald();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMiddleware<Herald.RouterMiddleware>("routes.json");
			//Router router = new Router("routes.json");
			//app.Run(async (context) =>
			//{
			//	var content = await router.RouteRequest(context.Request);
			//	context.Response.StatusCode = (int)content.StatusCode;
			//	context.Response.ContentType = "application/json";
			//	await context.Response.WriteAsync(await content.Content.ReadAsStringAsync());
			//});
		}
	}
}
