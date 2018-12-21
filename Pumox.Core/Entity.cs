using System;

namespace Pumox.Core
{
	public abstract class Entity
	{
		public Guid Id { get; }

		protected Entity(Guid id)
		{
			Id = id;
		}

		public override bool Equals(object obj)
		{
			var entity = obj as Entity;

			if (entity == null)
				return false;

			if (GetType() != entity.GetType())
				return false;

			if (Id == Guid.Empty || entity.Id == Guid.Empty)
				return false;

			if (ReferenceEquals(this, entity))
				return true;

			return Id == entity.Id;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id);
		}

		public static bool operator ==(Entity left, Entity right)
		{
			if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
				return true;

			if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
				return false;

			return left.Equals(right);
		}

		public static bool operator !=(Entity left, Entity right)
		{
			return !(left == right);
		}
	}
}
