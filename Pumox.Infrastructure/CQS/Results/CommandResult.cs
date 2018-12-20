namespace Pumox.Infrastructure.CQS.Results
{
	public class CommandResult : ICommandResult
	{
		public bool Succeeded { get; set; }
	}
}
