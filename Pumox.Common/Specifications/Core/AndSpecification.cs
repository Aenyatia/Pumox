﻿using System;
using System.Linq.Expressions;

namespace Pumox.Common.Specifications.Core
{
	internal sealed class AndSpecification<T> : Specification<T>
	{
		private readonly Specification<T> _left;
		private readonly Specification<T> _right;

		public AndSpecification(Specification<T> left, Specification<T> right)
		{
			_left = left;
			_right = right;
		}

		public override Expression<Func<T, bool>> ToExpression()
		{
			Expression<Func<T, bool>> left = _left.ToExpression();
			Expression<Func<T, bool>> right = _right.ToExpression();

			InvocationExpression invocationExpression = Expression.Invoke(right, left.Parameters);

			return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Body, invocationExpression), left.Parameters);
		}
	}
}
