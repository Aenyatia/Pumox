//using Pumox.Domain;
//using System;
//using System.Linq;
//using System.Linq.Expressions;

//namespace Pumox.Specifications
//{
//	internal sealed class AllTrue<T> : Specification<T>
//	{
//		public override Expression<Func<T, bool>> ToExpression()
//		{
//			return T => true;
//		}
//	}
//	internal sealed class AllFalse<T> : Specification<T>
//	{
//		public override Expression<Func<T, bool>> ToExpression()
//		{
//			return T => false;
//		}
//	}

//	public abstract class Specification<T>
//	{
//		public static readonly Specification<T> AllTrue = new AllTrue<T>();
//		public static readonly Specification<T> AllFalse = new AllFalse<T>();

//		public abstract Expression<Func<T, bool>> ToExpression();

//		public bool IsSatisfiedBy(T entity)
//		{
//			Func<T, bool> predicate = ToExpression().Compile();

//			return predicate(entity);
//		}

//		public Specification<T> And(Specification<T> right)
//		{
//			if (ReferenceEquals(right, null))
//				throw new NullReferenceException();

//			if (ReferenceEquals(this, AllFalse) || ReferenceEquals(right, AllFalse))
//				return AllFalse;

//			if (ReferenceEquals(this, AllTrue))
//				return right;

//			if (ReferenceEquals(right, AllTrue))
//				return this;

//			return new AndSpecification<T>(this, right);
//		}

//		public Specification<T> Or(Specification<T> right)
//		{
//			if (ReferenceEquals(right, null))
//				throw new NullReferenceException();

//			if (ReferenceEquals(this, AllFalse))
//				return right;

//			if (ReferenceEquals(right, AllFalse))
//				return this;

//			if (ReferenceEquals(this, AllTrue) || ReferenceEquals(right, AllTrue))
//				return AllTrue;

//			return new OrSpecification<T>(this, right);
//		}

//		public Specification<T> Not()
//		{
//			return new NotSpecification<T>(this);
//		}
//	}

//	internal sealed class AndSpecification<T> : Specification<T>
//	{
//		private readonly Specification<T> _left;
//		private readonly Specification<T> _right;

//		public AndSpecification(Specification<T> left, Specification<T> right)
//		{
//			_left = left;
//			_right = right;
//		}

//		public override Expression<Func<T, bool>> ToExpression()
//		{
//			Expression<Func<T, bool>> left = _left.ToExpression();
//			Expression<Func<T, bool>> right = _right.ToExpression();

//			InvocationExpression invocationExpression = Expression.Invoke(right, left.Parameters);

//			return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Body, invocationExpression), left.Parameters);
//		}
//	}
//	internal sealed class OrSpecification<T> : Specification<T>
//	{
//		private readonly Specification<T> _left;
//		private readonly Specification<T> _right;

//		public OrSpecification(Specification<T> left, Specification<T> right)
//		{
//			_left = left;
//			_right = right;
//		}

//		public override Expression<Func<T, bool>> ToExpression()
//		{
//			Expression<Func<T, bool>> left = _left.ToExpression();
//			Expression<Func<T, bool>> right = _right.ToExpression();

//			InvocationExpression invocationExpression = Expression.Invoke(right, left.Parameters);

//			return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left.Body, invocationExpression), left.Parameters);
//		}
//	}
//	internal sealed class NotSpecification<T> : Specification<T>
//	{
//		private readonly Specification<T> _specification;

//		public NotSpecification(Specification<T> specification)
//		{
//			_specification = specification;
//		}

//		public override Expression<Func<T, bool>> ToExpression()
//		{
//			Expression<Func<T, bool>> expression = _specification.ToExpression();

//			return Expression.Lambda<Func<T, bool>>(Expression.Not(expression.Body), expression.Parameters);
//		}
//	}

//	public class EmployeeBirthFrom : Specification<Company>
//	{
//		private readonly DateTime _dateFrom;

//		public EmployeeBirthFrom(DateTime dateFrom)
//		{
//			_dateFrom = dateFrom;
//		}

//		public override Expression<Func<Company, bool>> ToExpression()
//		{
//			return c => c.Employees.Any(e => e.DateOfBirth >= _dateFrom);
//		}
//	}
//	public class EmployeeBirthTo : Specification<Company>
//	{
//		private readonly DateTime _dateTo;

//		public EmployeeBirthTo(DateTime dateTo)
//		{
//			_dateTo = dateTo;
//		}

//		public override Expression<Func<Company, bool>> ToExpression()
//		{
//			return c => c.Employees.Any(e => e.DateOfBirth <= _dateTo);
//		}
//	}
//	public class EmployeeJobTitle : Specification<Company>
//	{
//		private readonly JobTitle _jobTitle;

//		public EmployeeJobTitle(JobTitle jobTitle)
//		{
//			_jobTitle = jobTitle;
//		}

//		public override Expression<Func<Company, bool>> ToExpression()
//		{
//			return c => c.Employees.Any(e => e.JobTitle == _jobTitle);
//		}
//	}
//	public class CompanyName : Specification<Company>
//	{
//		private readonly string _name;

//		public CompanyName(string name)
//		{
//			_name = name;
//		}

//		public override Expression<Func<Company, bool>> ToExpression()
//		{
//			return c => c.Name == _name;
//		}
//	}
//}
