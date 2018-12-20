using System.Threading.Tasks;

namespace Pumox.CQS.Core.Command
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Task<IResult> Handle(TCommand command);
	}
}
