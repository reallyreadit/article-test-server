// Copyright (C) 2022 reallyread.it, inc.
// 
// This file is part of Readup.
// 
// Readup is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License version 3 as published by the Free Software Foundation.
// 
// Readup is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License version 3 along with Foobar. If not, see <https://www.gnu.org/licenses/>.

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
