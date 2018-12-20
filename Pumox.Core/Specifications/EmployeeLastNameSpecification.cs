﻿using Pumox.Core.Domain;
using Pumox.Core.Specifications.Core;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pumox.Core.Specifications
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