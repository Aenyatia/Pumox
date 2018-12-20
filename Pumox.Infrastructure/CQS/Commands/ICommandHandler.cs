using System.Threading.Tasks;
using Pumox.Infrastructure.CQS.Results;

namespace Pumox.Infrastructure.CQS.Commands
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Task<ICommandResult> Handle(TCommand command);
	}
}
