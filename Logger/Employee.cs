using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class Employee : BasePerson
{
    public int EmployeeID { get; }
    public string? Profession { get; }

    public Employee(Guid id, string firstName, string lastName, string? middleName, int employeeId, string? profession) :
        base(id, firstName, lastName, middleName)
    {
        EmployeeID = employeeId;
        Profession = profession;
    }
}
