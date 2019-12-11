// <copyright file="IAuthenticator.cs" company="Ayvan">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2019-11-24</date>

namespace Herald.Contracts
{
	using Microsoft.AspNetCore.Http;

	/// <summary>
	/// Defines the <see cref="IAuthenticator" />
	/// </summary>
	public interface IAuthenticator
	{
		/// <summary>
		/// The Authenticate
		/// </summary>
		/// <param name="authenticationType">The authenticationType<see cref="string"/></param>
		/// <param name="httpContext">The httpContext<see cref="HttpContext"/></param>
		void Authenticate(string authenticationType, HttpContext httpContext);
	}
}
