// <copyright file="User.cs" company="Ayvan">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2019-11-24</date>

namespace Core.GatewayAPI.Services.Models
{
	/// <summary>
	/// Defines the <see cref="User" />
	/// </summary>
	public class User
	{
		/// <summary>
		/// Gets or sets the FullName
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Gets or sets the ID
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the InteranlID
		/// </summary>
		public string InteranlID { get; set; }

		/// <summary>
		/// Gets or sets the UserName
		/// </summary>
		public string UserName { get; set; }
	}
}
