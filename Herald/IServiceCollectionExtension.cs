// <copyright file="IServiceCollectionExtension.cs" company="Ayvan">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2019-11-24</date>

namespace Herald
{
	using Herald.Contracts;
	using Herald.Exceptions;
	using Herald.Utils;
	using Microsoft.Extensions.DependencyInjection;

	/// <summary>
	/// Defines the <see cref="IServiceCollectionExtension" />
	/// </summary>
	public static class IServiceCollectionExtension
	{
		/// <summary>
		/// The AddHerald
		/// </summary>
		/// <param name="services">The services<see cref="IServiceCollection"/></param>
		/// <returns>The <see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddHerald(this IServiceCollection services)
		{
			services.AddSingleton<IRouteHelper, RouteHelper>();
			services.AddTransient<IExceptionTransformer, BaseExceptionTransformer>();

			return services;
		}
	}
}
