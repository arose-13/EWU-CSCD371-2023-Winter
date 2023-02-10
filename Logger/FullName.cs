namespace Logger;

/**
* We created a value type record to define for futher immunitablitily and equivalence behavior
* Full name is not immutable because first, last, and middle should not change with each entity instance
**/

public record struct FullName(string FirstName, string LastName, string? MiddleName = null)
{
    public string FirstName { get; } = FirstName ?? throw new ArgumentNullException(nameof(FirstName));
    public string LastName { get; } = LastName ?? throw new ArgumentNullException(nameof(LastName));
    public string? MiddleName { get; } = MiddleName;
}
