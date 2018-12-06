﻿using Pumox.Domain;
using Pumox.Specifications.Core;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pumox.Specifications
{
	public class EmployeeJobTitle : Specification<Company>
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