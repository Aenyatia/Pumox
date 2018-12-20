using System.Threading.Tasks;
using Pumox.Infrastructure.CQS.Results;

namespace Pumox.Infrastructure.CQS.Commands
{
	public interface ICommandDispatcher
	{
		Task<ICommandResult> Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
	}
}
