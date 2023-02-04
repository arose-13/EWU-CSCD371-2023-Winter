namespace Logger;

// Implicit implementation of `IEntity` allows us to declare `Name` as abstract, thus putting the responsibility of
// implementation on deriving classes.
abstract class BaseEntity : IEntity
{
    public Guid ID {get; init;}
    public abstract string Name {get; set;}
}