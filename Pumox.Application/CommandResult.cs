using System.Collections.Generic;
using Pumox.Common.CQS.Results;

namespace Pumox.Application
{
	public class CommandResult : ICommandResult
	{
		private readonly List<string> _errors = new List<string>();

		public IEnumerable<string> Errors => _errors;
		public bool Succeeded { get; }

		public CommandResult(bool succeeded)
		{
			Succeeded = succeeded;
		}

		public CommandResult(bool succeeded, string errors)
		{
			Succeeded = succeeded;
			AddErrors(errors);
		}

		public CommandResult(bool succeeded, IEnumerable<string> errors)
		{
			Succeeded = succeeded;
			AddErrors(errors);
		}

		public void AddErrors(string error)
			=> _errors.Add(error);

		public void AddErrors(IEnumerable<string> errors)
			=> _errors.AddRange(errors);

		public static CommandResult Fail(string errors)
			=> new CommandResult(false, errors);

		public static CommandResult Fail(IEnumerable<string> errors)
			=> new CommandResult(false, errors);

		public static CommandResult Ok()
			=> new CommandResult(true);
	}
}
