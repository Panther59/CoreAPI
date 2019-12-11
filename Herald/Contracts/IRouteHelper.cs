// <copyright file="IRouteHelper.cs" company="Ayvan">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2019-11-24</date>

using Herald.Models;

namespace Herald.Contracts
{
	/// <summary>
	/// Defines the <see cref="IRouteHelper" />
	/// </summary>
	public interface IRouteHelper
	{
		/// <summary>
		/// The GetRouteDetail
		/// </summary>
		/// <param name="basePath">The basePath<see cref="string"/></param>
		/// <returns>The <see cref="Destination"/></returns>
		Route GetRouteDetail(string basePath);

		/// <summary>
		/// The LoadRoutes
		/// </summary>
		/// <param name="path">The path<see cref="string"/></param>
		void LoadRoutes(string path = "routes.json");
	}
}
