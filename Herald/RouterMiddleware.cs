// <copyright file="RouterMiddleware.cs" company="Ayvan">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2019-11-23</date>

namespace Herald
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net.Http;
	using System.Threading.Tasks;
	using Herald.Contracts;
	using Herald.Models;
	using Microsoft.AspNetCore.Http;
	using Microsoft.Extensions.Primitives;

	/// <summary>
	/// Defines the <see cref="RouterMiddleware" />
	/// </summary>
	public class RouterMiddleware
	{
		/// <summary>
		/// Defines the authenticator
		/// </summary>
		private readonly IAuthenticator authenticator;

		/// <summary>
		/// Defines the exceptionTransformer
		/// </summary>
		private readonly IExceptionTransformer exceptionTransformer;

		/// <summary>
		/// Defines the next
		/// </summary>
		private readonly RequestDelegate next;

		/// <summary>
		/// Defines the routeHelper
		/// </summary>
		private readonly IRouteHelper routeHelper;

		/// <summary>
		/// Initializes a new instance of the <see cref="RouterMiddleware"/> class.
		/// </summary>
		/// <param name="next">The next<see cref="RequestDelegate"/></param>
		/// <param name="routeHelper">The routeHelper<see cref="IRouteHelper"/></param>
		/// <param name="authenticator">The authenticator<see cref="IAuthenticator"/></param>
		/// <param name="exceptionTransformer">The exceptionTransformer<see cref="IExceptionTransformer"/></param>
		/// <param name="path">The path<see cref="string"/></param>
		public RouterMiddleware(
			RequestDelegate next,
			IRouteHelper routeHelper,
			IAuthenticator authenticator,
			IExceptionTransformer exceptionTransformer,
			string path = "routes.json")
		{
			this.next = next;
			this.routeHelper = routeHelper;
			this.authenticator = authenticator;
			this.exceptionTransformer = exceptionTransformer;

			this.routeHelper.LoadRoutes(path);
		}

		/// <summary>
		/// Gets or sets the AuthenticationService
		/// </summary>
		public Destination AuthenticationService { get; set; }

		/// <summary>
		/// Gets or sets the Routes
		/// </summary>

		/// <summary>
		/// The Invoke
		/// </summary>
		/// <param name="context">The context<see cref="HttpContext"/></param>
		/// <returns>The <see cref="Task"/></returns>
		public async Task Invoke(HttpContext context)
		{
			var request = context.Request;
			string path = request.Path.ToString();
			string basePath = '/' + path.Split('/')[1];

			Route route = this.routeHelper.GetRouteDetail(basePath);

			if (authenticator != null)
			{
				this.authenticator.Authenticate(route.AuthenticationType, context);
			}

			var content = await route.Destination.SendRequest(request);
			context.Response.StatusCode = (int)content.StatusCode;
			context.Response.ContentType = "application/json";
			var stream = await content.Content.ReadAsStreamAsync();
			await stream.CopyToAsync(context.Response.Body).ConfigureAwait(true);
			return;
		}
	}
}
