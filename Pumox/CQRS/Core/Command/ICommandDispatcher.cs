using System.Threading.Tasks;

namespace Pumox.CQRS.Core.Command
{
	public interface ICommandDispatcher
	{
		Task<IResult> Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
	}
}
