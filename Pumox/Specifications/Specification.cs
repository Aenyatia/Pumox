using Pumox.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Pumox.Specifications
{
	public sealed class BaseTrue<T> : Specification<T>
	{
		public override Expression<Func<T, bool>> ToExpression()
		{
			return T => true;
		}
	}

	public sealed class BaseFalse<T> : Specification<T>
	{
		public override Expression<Func<T, bool>> ToExpression()
		{
			return T => false;
		}
	}

	public interface ISpecification<T>
	{
		Expression<Func<T, bool>> ToExpression();
		bool IsSatisfiedBy(T entity);
		Specification<T> And(Specification<T> specification);
		Specification<T> Or(Specification<T> specification);
		Specification<T> Not();
	}

	public abstract class Specification<T> : ISpecification<T>
	{
		public static readonly Specification<T> True = new BaseTrue<T>();
		public static readonly Specification<T> False = new BaseFalse<T>();

		public abstract Expression<Func<T, bool>> ToExpression();

		public bool IsSatisfiedBy(T entity)
		{
			Func<T, bool> predicate = ToExpression().Compile();

			return predicate(entity);
		}

		public Specification<T> And(Specification<T> specification)
		{
			if (this == True)
				return specification;

			if (specification == True)
				return this;

			return new AndSpecification<T>(this, specification);
		}

		public Specification<T> Or(Specification<T> specification)
		{
			if (this == False)
				return specification;

			//if (this == True || specification == True)
			//	return True;

			return new OrSpecification<T>(this, specification);
		}

		public Specification<T> Not()
		{
			return new NotSpecification<T>(this);
		}
	}

	public sealed class AndSpecification<T> : Specification<T>
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
			var left = _left.ToExpression();
			var right = _right.ToExpression();

			var invokedExpression = Expression.Invoke(right, left.Parameters);

			return (Expression<Func<T, bool>>)Expression.Lambda(Expression.AndAlso(left.Body, invokedExpression), left.Parameters);
		}
	}
	public sealed class OrSpecification<T> : Specification<T>
	{
		private readonly Specification<T> _left;
		private readonly Specification<T> _right;

		public OrSpecification(Specification<T> left, Specification<T> right)
		{
			_left = left;
			_right = right;
		}

		public override Expression<Func<T, bool>> ToExpression()
		{
			var left = _left.ToExpression();
			var right = _right.ToExpression();

			var invokedExpression = Expression.Invoke(right, left.Parameters);

			return (Expression<Func<T, bool>>)Expression.Lambda(Expression.OrElse(left.Body, invokedExpression), left.Parameters);

		}
	}
	public sealed class NotSpecification<T> : Specification<T>
	{
		private readonly Specification<T> _specification;

		public NotSpecification(Specification<T> specification)
		{
			_specification = specification;
		}

		public override Expression<Func<T, bool>> ToExpression()
		{
			var expression = _specification.ToExpression();

			var notExpression = Expression.Not(expression.Body);

			return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
		}
	}

	public class EmployeeBirthFrom : Specification<Company>
	{
		private readonly DateTime _dateFrom;

		public EmployeeBirthFrom(DateTime dateFrom)
		{
			_dateFrom = dateFrom;
		}

		public override Expression<Func<Company, bool>> ToExpression()
		{
			return c => c.Employees.Any(e => e.DateOfBirth >= _dateFrom);
		}
	}
	public class EmployeeBirthTo : Specification<Company>
	{
		private readonly DateTime _dateTo;

		public EmployeeBirthTo(DateTime dateTo)
		{
			_dateTo = dateTo;
		}

		public override Expression<Func<Company, bool>> ToExpression()
		{
			return c => c.Employees.Any(e => e.DateOfBirth <= _dateTo);
		}
	}
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
	public class CompanyName : Specification<Company>
	{
		private readonly string _name;

		public CompanyName(string name)
		{
			_name = name;
		}

		public override Expression<Func<Company, bool>> ToExpression()
		{
			return c => c.Name == _name;
		}
	}
}
