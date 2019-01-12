using System;
using System.Linq.Expressions;
using Pumox.Common.Specifications.Core;

namespace Pumox.Common.Specifications
{
	public sealed class CompanyNameSpecification : Specification<Company>
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
