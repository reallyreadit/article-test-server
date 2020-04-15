using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using article_test_server.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace article_test_server.Controllers {
	public class ArticlesController : Controller {
		public IActionResult Index([FromServices] IOptions<NetworkDelayOptions> options, string view) {
			if (!Request.Cookies.ContainsKey("id")) {
				return RedirectToRoute(
					new {
						Action = "Assign",
						Controller = "Identity",
						RedirectUrl = Request.Path
					}
				);
			}
			Thread.Sleep(options.Value.ArticlePageDelay);
			return View(view);
		}
	}
}
