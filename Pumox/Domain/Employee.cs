using System;
using System.ComponentModel.DataAnnotations;

namespace Pumox.Domain
{
	public class Employee
	{
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public DateTime DateOfBirth { get; set; }

		[Required]
		[EnumDataType(typeof(JobTitle))]
		public JobTitle JobTitle { get; set; }

		//public long CompanyId { get; set; }
		//public Company Company { get; set; }
	}
}
