﻿using System.Diagnostics;
using Core.HelperWindowsService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Core.HelperWindowsService.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			this._logger = logger;
		}

		public IActionResult Index()
		{
			return this.View();
		}

		public IActionResult Privacy()
		{
			return this.View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
		}
	}
}
