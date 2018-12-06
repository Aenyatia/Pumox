﻿using System;
using System.Linq.Expressions;

namespace Pumox.Specifications.Core
{
	internal sealed class AllFalseSpecification<T> : Specification<T>
	{
		public override Expression<Func<T, bool>> ToExpression()
		{
			return T => false;
		}
	}
}