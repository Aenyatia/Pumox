using System.Threading.Tasks;

namespace Pumox.CQRS.Core.Command
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Task<IResult> Handle(TCommand command);
	}
}
