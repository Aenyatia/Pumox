using System.Threading.Tasks;

namespace Pumox.CommandsQueries.Core.Command
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Task<IResult> Handle(TCommand command);
	}
}
