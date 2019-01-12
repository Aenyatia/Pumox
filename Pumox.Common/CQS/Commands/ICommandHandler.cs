using System.Threading.Tasks;

namespace Pumox.Common.CQS.Commands
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Task Handle(TCommand command);
	}
}
