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
		public IActionResult Index(string path, [FromServices] IHostingEnvironment hostEnv, [FromServices] IOptions<NetworkDelayOptions> options) {
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
