using System.Collections.Generic;

namespace Pumox.Common.CQS.Results
{
	public interface ICommandResult
	{
		bool Succeeded { get; }
		IEnumerable<string> Errors { get; }

		void AddErrors(string error);
		void AddErrors(IEnumerable<string> errors);
	}
}
