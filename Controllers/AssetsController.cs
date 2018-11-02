using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace article_test_server.Controllers {
	public class AssetsController : Controller {
		public IActionResult Index(string path, [FromServices] IHostingEnvironment hostEnv) {
			string contentType;
			if (new FileExtensionContentTypeProvider().TryGetContentType(Path.Combine(hostEnv.WebRootPath, path), out contentType)) {
				switch (path.Split('.').Last()) {
					case "js":
						Thread.Sleep(2000);
						break;
					case "css":
						Thread.Sleep(2000);
						break;
					case "jpg":
						Thread.Sleep(2000);
						break;
				}
				return File(path, contentType);
			}
			return BadRequest();
		}
	}
}
