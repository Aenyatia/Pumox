using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pumox.Application;
using Pumox.Infrastructure.EntityFramework;
using Pumox.Infrastructure.EntityFramework.Repositories;
using System;
using Pumox.Core.Companies;
using Pumox.Core.Shared;

namespace Pumox
{
	public class Startup
	{
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
				.AddFluentValidation(options =>
				{
					options.RegisterValidatorsFromAssemblyContaining<Startup>();
					options.LocalizationEnabled = false;
				});

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseInMemoryDatabase("Pumox"));

			// configure autofac
			var builder = new ContainerBuilder();
			builder.Populate(services);

			// register modules
			builder.RegisterModule<CqsModule>();
			builder.RegisterType<Fake>()
				.As<ICompanyRepository>()
				.InstancePerLifetimeScope();

			builder.RegisterType<UnitOfWork>()
				.As<IUnitOfWork>()
				.InstancePerLifetimeScope();

			return new AutofacServiceProvider(builder.Build());
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
