using System.Threading.Tasks;

namespace Pumox.CQS.Core.Command
{
	public interface ICommandDispatcher
	{
		Task<IResult> Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
	}
}
