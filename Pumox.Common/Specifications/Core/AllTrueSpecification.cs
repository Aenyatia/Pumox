using System;
using System.Linq.Expressions;

namespace Pumox.Common.Specifications.Core
{
	internal sealed class AllTrueSpecification<T> : Specification<T>
	{
		public override Expression<Func<T, bool>> ToExpression()
		{
			return t => true;
		}
	}
}
