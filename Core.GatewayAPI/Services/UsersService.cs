// <copyright file="UsersService.cs" company="Ayvan">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2019-11-24</date>

namespace Core.GatewayAPI.Services
{
	using System;
	using System.Collections.Generic;
	using Core.GatewayAPI.Services.Contracts;
	using Core.GatewayAPI.Services.Models;
	using Herald.Utils;

	/// <summary>
	/// Defines the <see cref="UsersService" />
	/// </summary>
	public class UsersService : IUsersService
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UsersService"/> class.
		/// </summary>
		public UsersService()
		{
			dynamic users = JsonLoader.LoadFromFile<dynamic>("users.json");

			this.Users = JsonLoader.Deserialize<List<User>>(Convert.ToString(users));
		}

		/// <summary>
		/// Gets the Users
		/// </summary>
		public List<User> Users { get; }

	}
}
