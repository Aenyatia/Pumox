﻿using Autofac;
using Pumox.Common.CQS.Commands;
using Pumox.Common.CQS.Queries;

namespace Pumox.Application
{
	public class CqsModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<CommandDispatcher>()
				.As<ICommandDispatcher>()
				.InstancePerLifetimeScope();

			builder.RegisterType<QueryDispatcher>()
				.As<IQueryDispatcher>()
				.InstancePerLifetimeScope();

			builder.RegisterAssemblyTypes(ThisAssembly)
				.AsClosedTypesOf(typeof(ICommandHandler<>))
				.InstancePerLifetimeScope();

			builder.RegisterAssemblyTypes(ThisAssembly)
				.AsClosedTypesOf(typeof(IQueryHandler<>))
				.InstancePerLifetimeScope();
		}
	}
}
