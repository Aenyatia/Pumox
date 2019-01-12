using System;
using System.Linq.Expressions;
using Pumox.Common.Specifications.Core;

namespace Pumox.Common.Specifications
{
	public sealed class EmployeeJobTitle : Specification<Company>
	{
		private readonly JobTitle _jobTitle;

		public EmployeeJobTitle(JobTitle jobTitle)
		{
			_jobTitle = jobTitle;
		}

		public override Expression<Func<Company, bool>> ToExpression()
		{
			return c => c.Employees.Any(e => e.JobTitle == _jobTitle);
		}
	}
}
