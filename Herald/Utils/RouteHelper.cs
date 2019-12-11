// <copyright file="RouteHelper.cs" company="Ayvan">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2019-11-24</date>

namespace Herald.Utils
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Herald.Contracts;
	using Herald.Models;

	/// <summary>
	/// Defines the <see cref="RouteHelper" />
	/// </summary>
	public class RouteHelper : IRouteHelper
	{
		/// <summary>
		/// Defines the isRoutesLoaded
		/// </summary>
		private bool isRoutesLoaded = false;

		/// <summary>
		/// Gets or sets the Routes
		/// </summary>
		public List<Route> Routes { get; set; }

		/// <inheritdoc />
		public Route GetRouteDetail(string basePath)
		{
			var route = this.Routes.FirstOrDefault(r => r.Endpoint.Equals(basePath));
			if (route != null)
			{
				return route;
			}
			else
			{
				throw new NotSupportedException("This method is not supported");
			}
		}

		/// <inheritdoc />
		public void LoadRoutes(string path = "routes.json")
		{
			if (this.isRoutesLoaded == false)
			{
				dynamic router = JsonLoader.LoadFromFile<dynamic>(path);

				this.Routes = JsonLoader.Deserialize<List<Route>>(Convert.ToString(router.routes));
				this.isRoutesLoaded = true;
			}
		}
	}
}
