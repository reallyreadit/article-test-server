using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace article_test_server.Controllers {
	public class ArticlesController : Controller {
		public IActionResult Index(string view) {
			Thread.Sleep(2000);
			return View(view);
		}
	}
}
