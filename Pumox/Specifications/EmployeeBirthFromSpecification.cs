using Pumox.Domain;
using Pumox.Specifications.Core;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pumox.Specifications
{
	public class EmployeeBirthFromSpecification : Specification<Company>
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
