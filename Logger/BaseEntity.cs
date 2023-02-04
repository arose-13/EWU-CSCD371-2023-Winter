namespace Logger;

abstract class BaseEntity : IEntity{
    public abstract Guid ID {get; init;}
    public abstract string Name {get; set;}
}