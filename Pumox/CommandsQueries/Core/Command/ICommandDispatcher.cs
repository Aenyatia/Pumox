using System.Threading.Tasks;

namespace Pumox.CommandsQueries.Core.Command
{
	public interface ICommandDispatcher
	{
		Task<IResult> Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
	}
}
