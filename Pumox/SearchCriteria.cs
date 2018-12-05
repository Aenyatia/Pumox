using System.Collections.Generic;

namespace Pumox
{
	public class SearchCriteria
	{
		public string Keyword { get; set; }
		public string EmployeeDateOfBirthFrom { get; set; }
		public string EmployeeDateOfBirthTo { get; set; }
		public IEnumerable<string> EmployeeJobTitles { get; set; } = new List<string>();
	}
}
