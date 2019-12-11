// <copyright file="BaseExceptionTransformer.cs" company="Ayvan">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2019-11-24</date>

namespace Herald.Exceptions
{
	using System;
	using Herald.Contracts;

	/// <summary>
	/// Defines the <see cref="ExceptionTransformer" />
	/// </summary>
	public class BaseExceptionTransformer : IExceptionTransformer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BaseExceptionTransformer"/> class.
		/// </summary>
		public BaseExceptionTransformer()
		{
		}

		public object TransformException(Exception ex)
		{
			return ex;
		}
	}
}
