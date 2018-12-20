using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pumox.Application;
using Pumox.Core.Repositories;
using Pumox.Infrastructure.EntityFramework;
using Pumox.Infrastructure.EntityFramework.Repositories;
using System;

namespace Pumox
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public IContainer ApplicationContainer { get; private set; }

		public Startup(IConfiguration configuration)
			=> Configuration = configuration;

		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseInMemoryDatabase("Pumox"));

			// configure autofac
			var builder = new ContainerBuilder();
			builder.Populate(services);

			// register modules
			builder.RegisterModule<CqsModule>();
			builder.RegisterType<CompanyRepository>()
				.As<ICompanyRepository>()
				.InstancePerLifetimeScope();

			builder.RegisterType<UnitOfWork>()
				.As<IUnitOfWork>()
				.InstancePerLifetimeScope();

			ApplicationContainer = builder.Build();
			return new AutofacServiceProvider(ApplicationContainer);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseHsts();

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
