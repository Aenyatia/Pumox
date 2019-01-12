using System.Collections.Generic;

namespace Pumox.Common.CQS.Results
{
	public class CommandResult : ICommandResult
	{
		public bool Succeeded { get; set; }
		public IEnumerable<string> Errors { get; }
		public void AddErrors(string error)
		{
			throw new System.NotImplementedException();
		}

		public void AddErrors(IEnumerable<string> errors)
		{
			throw new System.NotImplementedException();
		}
	}
}
