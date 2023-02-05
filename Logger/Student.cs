using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class Student : BasePerson
{
    public Student(Guid id, string firstName, string lastName, string? middleName) : base(id, firstName, lastName, middleName)
    {
    }
}
