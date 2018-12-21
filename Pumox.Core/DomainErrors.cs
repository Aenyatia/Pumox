namespace Pumox.Core
{
	public class DomainError
	{
		public Code Code { get; set; }
		public string Message { get; set; }

		public static string FirstNameRequired => "First name is required.";
		public static string LastNameRequired => "Last name is required.";
		public static string InvalidBirthdate => "Birthday is invalid.";
	}

	public enum Code
	{
		InvalidName,
		InvalidBirthdate,
		InvalidJobTitle
	}
}
