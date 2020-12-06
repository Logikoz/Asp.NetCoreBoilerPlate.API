using Asp.NetCoreBoilerPlate.API.Extensions.StartupRegisters;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Asp.NetCoreBoilerPlate.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
				.AddJsonOptions(configure =>
				{
					configure.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
					configure.JsonSerializerOptions.IgnoreNullValues = true;
				})
				.AddMvcOptions(options => options.AddMvcOptionsRegister());

			services.AddSwaggerGen(setup =>
			{
				setup.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Asp.NetCore Boiler Plate API",
					Description = "Documentaçao da API "
				});

				setup.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"docs.xml"), true);
			});

			services.RegisterBusiness();
			services.RegisterRepository();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseRouting();

			app.UseSwagger();

			app.UseStaticFiles();

			const string docsPrefix = "api/docs";

			app.UseReDoc(x =>
			{
				x.RoutePrefix = docsPrefix;
				x.SpecUrl = "/swagger/v1/swagger.json";
			});

			app.UseSwaggerUI(c =>
			{
				c.RoutePrefix = $"{docsPrefix}/test";
				c.SwaggerEndpoint("/swagger/v1/swagger.json", null);
				c.InjectStylesheet("/docs/custom.css");
			});

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapGet("/", async (e) =>
				{
					string[] fullName = typeof(Startup).Assembly.FullName.Split(',');

					await e.Response.WriteAsync(JsonSerializer.Serialize(new
					{
						Environment = env.EnvironmentName,
						Name = fullName[0],
						Version = fullName[1].Remove(0, 9),
						Docs = $"{e.Request.Scheme}://{e.Request.Host}/{docsPrefix}"
					}));
				});
			});
		}
	}
}