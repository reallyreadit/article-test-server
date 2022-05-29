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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using article_test_server.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace article_test_server {
	public class Startup {
		private readonly IWebHostEnvironment env;
		private readonly IConfigurationRoot config;
		public Startup(IWebHostEnvironment env) {
			// set the IWebHostEnvironment
			this.env = env;
			// read configuration
			var currentDirectory = Directory.GetCurrentDirectory();
			var config = new ConfigurationBuilder()
				.SetBasePath(currentDirectory)
				.AddJsonFile("appsettings.json");
			var envConfigFile = $"appsettings.{env.EnvironmentName}.json";
			if (File.Exists(Path.Combine(currentDirectory, envConfigFile))) {
				config.AddJsonFile(envConfigFile);
			}
			this.config = config.Build();
		}
		public void ConfigureServices(IServiceCollection services) {
			// configure options
			services.Configure<NetworkDelayOptions>(config.GetSection("NetworkDelay"));
			services.AddMvc();
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			app.UseDeveloperExceptionPage();

			app.UseRouting();

			app.UseEndpoints(routes => {
				routes.MapControllerRoute(
					name: "identity",
					pattern: "Identity/Assign",
					defaults: new {
						Action = "Assign",
						Controller = "Identity"
					}
				);
				routes.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{view}",
					defaults: new {
						Action = "Index",
						Controller = "Home",
						View = "Index"
					}
				);
				routes.MapControllerRoute(
					name: "assets",
					pattern: "Assets/{*path}",
					defaults: new {
						Action = "Index",
						Controller = "Assets"
					}
				);
			});
		}
	}
}
