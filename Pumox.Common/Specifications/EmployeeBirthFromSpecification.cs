using Pumox.Common.Specifications.Core;
using Pumox.Core.Companies;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pumox.Common.Specifications
{
	public sealed class EmployeeBirthFromSpecification : Specification<Company>
	{
		private readonly DateTime _birthFrom;

		public EmployeeBirthFromSpecification(DateTime birthFrom)
		{
			_birthFrom = birthFrom;
		}

		public override Expression<Func<Company, bool>> ToExpression()
		{
			return c => c.Employees.Any(e => e.DateOfBirth >= _birthFrom);
		}
	}
}
