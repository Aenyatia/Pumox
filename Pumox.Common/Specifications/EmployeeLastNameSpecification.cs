using Pumox.Common.Specifications.Core;
using Pumox.Core.Companies;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pumox.Common.Specifications
{
	public sealed class EmployeeLastNameSpecification : Specification<Company>
	{
		private readonly string _lastName;

		public EmployeeLastNameSpecification(string lastName)
		{
			_lastName = lastName;
		}

		public override Expression<Func<Company, bool>> ToExpression()
		{
			return c => c.Employees.Any(e => e.LastName.Contains(_lastName));
		}
	}
}
