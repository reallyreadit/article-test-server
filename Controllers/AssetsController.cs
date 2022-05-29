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
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using article_test_server.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;

namespace article_test_server.Controllers {
	public class AssetsController : Controller {
		public IActionResult Index(string path, [FromServices] IWebHostEnvironment hostEnv, [FromServices] IOptions<NetworkDelayOptions> options) {
			string contentType;
			if (new FileExtensionContentTypeProvider().TryGetContentType(Path.Combine(hostEnv.WebRootPath, path), out contentType)) {
				switch (path.Split('.').Last()) {
					case "js":
						Thread.Sleep(options.Value.JavascriptFileDelay);
						break;
					case "css":
						Thread.Sleep(options.Value.CssFileDelay);
						break;
					case "jpg":
						Thread.Sleep(options.Value.ImageFileDelay);
						break;
				}
				return File(path, contentType);
			}
			return BadRequest();
		}
	}
}
