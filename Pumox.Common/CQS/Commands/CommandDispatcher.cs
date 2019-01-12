using Autofac;
using System;
using System.Threading.Tasks;

namespace Pumox.Common.CQS.Commands
{
	public sealed class CommandDispatcher : ICommandDispatcher
	{
		private readonly IComponentContext _componentContext;

		public CommandDispatcher(IComponentContext componentContext)
		{
			_componentContext = componentContext ?? throw new ArgumentNullException(nameof(componentContext));
		}

		public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
		{
			if (command == null)
				throw new ArgumentNullException(nameof(command));

			var handler = _componentContext.Resolve<ICommandHandler<TCommand>>();

			await handler.Handle(command);
		}
	}
}
