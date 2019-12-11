// <copyright file="Authenticator.cs" company="Ayvan">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2019-11-24</date>

namespace Core.GatewayAPI
{
	using Core.GatewayAPI.Services.Contracts;
	using Herald.Contracts;
	using Microsoft.AspNetCore.Http;

	/// <summary>
	/// Defines the <see cref="Authenticator" />
	/// </summary>
	public class Authenticator : IAuthenticator
	{
		/// <summary>
		/// Defines the usersService
		/// </summary>
		private readonly IUsersService usersService;

		/// <summary>
		/// Initializes a new instance of the <see cref="Authenticator"/> class.
		/// </summary>
		/// <param name="usersService">The usersService<see cref="IUsersService"/></param>
		public Authenticator(IUsersService usersService)
		{
			this.usersService = usersService;
		}

		/// <inheritdoc />
		public void Authenticate(string authenticationType, HttpContext httpContext)
		{
		}
	}
}
