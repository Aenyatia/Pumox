using Pumox.Common.Specifications.Core;
using Pumox.Core.Companies;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pumox.Common.Specifications
{
	public sealed class EmployeeFirstNameSpecification : Specification<Company>
	{
		private readonly string _firstName;

		public EmployeeFirstNameSpecification(string firstName)
		{
			_firstName = firstName;
		}

		public override Expression<Func<Company, bool>> ToExpression()
		{
			return c => c.Employees.Any(e => e.FirstName.Contains(_firstName));
		}
	}
}
