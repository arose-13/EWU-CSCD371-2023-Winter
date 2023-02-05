using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public abstract record class BasePerson : BaseEntity
{
    // Implicit implementation so that we can create a class-specific Name implementation
    public override string Name 
    {
        get 
        {
            if (string.IsNullOrWhiteSpace(FullName.MiddleName))
                return FullName.FirstName + " " + FullName.LastName;
            else
                return FullName.FirstName + " " + FullName.MiddleName + " " + FullName.LastName;
        }
    }

    public FullName FullName { get; init; }

    public BasePerson(Guid id, string firstName, string lastName, string? middleName)
    {
        ID = id;
        FullName = new FullName(firstName, lastName, middleName!);
    }
}
