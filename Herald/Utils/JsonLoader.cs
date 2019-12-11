// <copyright file="JsonLoader.cs" company="Ayvan">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2019-11-23</date>

namespace Herald.Utils
{
	using System;
	using System.IO;
	using Newtonsoft.Json;

	/// <summary>
	/// Defines the <see cref="JsonLoader" />
	/// </summary>
	public class JsonLoader
	{
		/// <summary>
		/// The Deserialize
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="jsonObject">The jsonObject<see cref="object"/></param>
		/// <returns>The <see cref="T"/></returns>
		public static T Deserialize<T>(object jsonObject)
		{
			return JsonConvert.DeserializeObject<T>(Convert.ToString(jsonObject));
		}

		/// <summary>
		/// The LoadFromFile
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="filePath">The filePath<see cref="string"/></param>
		/// <returns>The <see cref="T"/></returns>
		public static T LoadFromFile<T>(string filePath)
		{
			using (StreamReader reader = new StreamReader(filePath))
			{
				string json = reader.ReadToEnd();
				T result = JsonConvert.DeserializeObject<T>(json);
				return result;
			}
		}
	}
}
