using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace article_test_server {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}
		public IConfiguration Configuration { get; }
		public void ConfigureServices(IServiceCollection services) {
			services.AddMvc();
		}
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
			app.UseDeveloperExceptionPage();

			app.UseMvc(routes => {
				routes
					.MapRoute(
						name: "assets",
						template: "Assets/{*path}",
						defaults: new {
							Action = "Index",
							Controller = "Assets"
						}
					)
					.MapRoute(
						name: "default",
						template: "{controller}/{view}",
						defaults: new {
							Action = "Index",
							Controller = "Home",
							View = "Index"
						}
					);
			});
		}
	}
}
