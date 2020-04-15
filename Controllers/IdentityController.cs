using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace article_test_server.Controllers {
	public class IdentityController : Controller {
		public IActionResult Assign([FromQuery] string redirectUrl) {
			if (!Request.Cookies.ContainsKey("id")) {
				Response.Cookies.Append(
					"id",
					Guid.NewGuid().ToString(),
					new CookieOptions() {
						Domain = ".article-test.dev.readup.com",
						Expires = DateTime.UtcNow.AddDays(180),
						HttpOnly = true,
						SameSite = SameSiteMode.None
					}
				);
			}
			return Redirect(redirectUrl);
		}
	}
}