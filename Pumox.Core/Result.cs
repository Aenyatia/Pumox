using System.Collections.Generic;

namespace Pumox.Core
{
	public class Result
	{
		public bool Success { get; set; }
		public string Error { get; set; }
		public IEnumerable<string> Errors { get; set; }
		public bool Failure => !Success;

		public Result(bool success, string error)
		{
			Success = success;
			Error = error;
		}

		public Result(bool success, IEnumerable<string> errors)
		{
			Success = success;
			Errors = errors;
		}

		public Result(bool success)
		{
			Success = success;
		}

		public static Result Fail(string message)
			=> new Result(false, message);

		public static Result Ok()
			=> new Result(true, string.Empty);

		public static Result<T> Fail<T>(string message)
			=> new Result<T>(false, message);

		public static Result<T> Fail<T>(IEnumerable<string> errors)
			=> new Result<T>(false, errors);

		public static Result<T> Ok<T>(T value)
			=> new Result<T>(true, value);
	}

	public class Result<T> : Result
	{
		public T Value { get; set; }

		public Result(bool success, string error)
			: base(success, error)
		{
		}

		public Result(bool success, IEnumerable<string> errors)
			: base(success, errors)
		{
		}

		public Result(bool success, T value)
			: base(success)
		{
			Value = value;
		}
	}
}
