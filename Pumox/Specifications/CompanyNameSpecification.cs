using Pumox.Domain;
using Pumox.Specifications.Core;
using System;
using System.Linq.Expressions;

namespace Pumox.Specifications
{
	public class CompanyNameSpecification : Specification<Company>
	{
		private readonly string _name;

		public CompanyNameSpecification(string name)
		{
			_name = name;
		}

		public override Expression<Func<Company, bool>> ToExpression()
		{
			return c => c.Name.Contains(_name);
		}
	}
}
