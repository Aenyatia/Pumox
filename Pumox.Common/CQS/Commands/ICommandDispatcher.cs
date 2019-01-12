using System.Threading.Tasks;

namespace Pumox.Common.CQS.Commands
{
	public interface ICommandDispatcher
	{
		Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
	}
}
