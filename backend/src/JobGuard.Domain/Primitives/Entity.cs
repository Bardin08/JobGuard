namespace JobGuard.Domain.Primitives;

public abstract class Entity(Guid id) : IEquatable<Entity>
{
    public Guid Id { get; private init; } = id;

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (obj.GetType() != GetType()) return false;
        if (obj is not Entity entity) return false;
        return entity.Id == Id;
    }

    public bool Equals(Entity? other)
    {
        if (other is null) return false;
        if (other.GetType() != GetType()) return false;
        return other.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity? lhs, Entity? rhs)
    {
        return lhs is not null &&
               rhs is not null &&
               lhs.Equals(rhs);
    }

    public static bool operator !=(Entity? lhs, Entity? rhs)
    {
        return !(lhs == rhs);
    }
}