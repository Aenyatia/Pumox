using System;
using System.Threading.Tasks;

namespace Pumox.CQS.Core.Command
{
	public sealed class CommandDispatcher : ICommandDispatcher
	{
		private readonly Func<Type, ICommandHandler<ICommand>> _handlersFactory;

		public CommandDispatcher(Func<Type, ICommandHandler<ICommand>> handlersFactory)
		{
			_handlersFactory = handlersFactory;
		}

		public async Task<IResult> Dispatch<TCommand>(TCommand command) where TCommand : ICommand
		{
			var handler = _handlersFactory(typeof(TCommand));
			return await handler.Handle(command);
		}
	}
}
