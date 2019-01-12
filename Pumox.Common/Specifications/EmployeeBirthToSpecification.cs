using System;
using System.Linq.Expressions;
using Pumox.Common.Specifications.Core;

namespace Pumox.Common.Specifications
{
	public sealed class EmployeeBirthToSpecification : Specification<Company>
	{
		private readonly DateTime _dateTo;

		public EmployeeBirthToSpecification(DateTime dateTo)
		{
			_dateTo = dateTo;
		}

		public override Expression<Func<Company, bool>> ToExpression()
		{
			return c => c.Employees.Any(e => e.DateOfBirth <= _dateTo);
		}
	}
}
