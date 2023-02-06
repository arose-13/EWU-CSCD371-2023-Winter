using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests;

[TestClass]
public class EmployeeTests
{
    [TestMethod]
    public void CreateEmployee_ReturnsNonNullEmployee()
    {
        // Assemble
        Guid id = Guid.NewGuid();
        Employee employee = new(id, "John", "Williams", "Towner", 1, "Composer");

        // Assert
        Assert.IsNotNull(employee);
    }
}
