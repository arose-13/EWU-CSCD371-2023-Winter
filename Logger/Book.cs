using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logger;

public record Book : BaseEntity
{
    public override string Name
    {
        get
        {
            ArgumentNullException.ThrowIfNullOrEmpty(ISBN);
            ArgumentNullException.ThrowIfNullOrEmpty(BookTitle);
            return $"{BookTitle}, ISBN: {ISBN}, Author: {Author}";
        }
    }
    public string? BookTitle { get; init; }
    public FullName Author { get; init; }
    public string? ISBN { get; init; }

    public Book(Guid id, string firstName, string lastName, string? middleName)
    {
        Id = id;
        Author = new FullName(firstName, lastName, middleName);
    }
}