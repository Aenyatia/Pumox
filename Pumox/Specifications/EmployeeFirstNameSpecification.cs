﻿using Pumox.Domain;
using Pumox.Specifications.Core;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pumox.Specifications
{
	public class EmployeeFirstNameSpecification : Specification<Company>
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
