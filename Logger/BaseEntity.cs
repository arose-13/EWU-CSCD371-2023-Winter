namespace Logger;

// Implicit implementation of `IEntity` allows us to declare `Name` as abstract, thus putting the responsibility of
// implementation on deriving classes.
public abstract record class BaseEntity : IEntity
{
    public Guid ID {get; init;}
    public abstract string Name { get; }
}