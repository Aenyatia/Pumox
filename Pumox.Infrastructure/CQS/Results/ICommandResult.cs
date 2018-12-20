namespace Pumox.Infrastructure.CQS.Results
{
	public interface ICommandResult
	{
		bool Succeeded { get; }
	}
}
