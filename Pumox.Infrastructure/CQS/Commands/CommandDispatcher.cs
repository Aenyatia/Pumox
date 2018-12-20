using Autofac;
using Pumox.Infrastructure.CQS.Results;
using System;
using System.Threading.Tasks;

namespace Pumox.Infrastructure.CQS.Commands
{
	public sealed class CommandDispatcher : ICommandDispatcher
	{
		private readonly IComponentContext _componentContext;

		public CommandDispatcher(IComponentContext componentContext)
		{
			_componentContext = componentContext ?? throw new ArgumentNullException(nameof(componentContext));
		}

		public async Task<ICommandResult> Dispatch<TCommand>(TCommand command) where TCommand : ICommand
		{
			if (command == null)
				throw new ArgumentNullException(nameof(command));

			var handler = _componentContext.Resolve<ICommandHandler<TCommand>>();

			return await handler.Handle(command);
		}
	}
}
