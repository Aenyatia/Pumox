﻿using Pumox.Core.Domain;
using Pumox.Core.Specifications.Core;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pumox.Core.Specifications
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