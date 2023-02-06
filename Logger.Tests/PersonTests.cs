using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests;

[TestClass]
public class PersonTests
{

    [TestMethod]
    public void CreateStudentWithMiddleName_ReturnsNonNullStudent()
    {
        // Assemble
        Guid id = Guid.NewGuid();
        Student student = new(id, "John", "Williams", "Towner");

        // Assert
        Assert.IsNotNull(student);
    }

    [TestMethod]
    public void CreateStudentWithNullMiddleName_ReturnsNonNullStudent()
    {
        // Assemble
        Guid id = Guid.NewGuid();
        Student student = new(id, "John", "Williams", null);

        // Assert
        Assert.IsNotNull(student);
    }

    [TestMethod]
    public void CreateStudentWithMiddleName_NameIsFullName()
    {
        // Assemble
        Guid id = Guid.NewGuid();
        Student student = new(id, "John", "Williams", "Towner");

        // Assert
        Assert.IsTrue(student.Name.Equals("John Towner Williams"));
    }

    [TestMethod]
    public void CreateStudentWithNullMiddleName_NameIsFirstAndLastNames()
    {
        // Assemble
        Guid id = Guid.NewGuid();
        Student student = new(id, "John", "Williams", null);

        // Assert
        Assert.IsTrue(student.Name.Equals("John Williams"));
    }
}
