using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests;

[TestClass]
public class StorageTests
{
    [TestMethod]
    public void Storage_AddsEntity_ReturnsEnityByID()
    {
        // Assemble
        Storage entity = new();
        Guid id = Guid.NewGuid();

        // Act
        Student student = new(id, "John", "Doe", "Nancy");
        entity.Add(student);

        // Assert
        Assert.IsNotNull(entity.Get(id));
        Assert.AreEqual(student, entity.Get(id));

    }


    [TestMethod]
    public void Storage_RemoveEnitity_ReturnsNull()
    {
        // Assemble
        Storage entity = new();
        Guid id = Guid.NewGuid();

        // Act
        Student student = new(id, "John", "Doe", "Nancy");
        entity.Add(student);
        entity.Remove(student);

        // Assert
        Assert.IsNull(entity.Get(id));
    }

    [TestMethod]
    public void Contains_FindsEnitity_ReturnsTrueIfEnityExists()
    {
        // Assemble
        Storage entity = new();
        Guid studentID = Guid.NewGuid();
        Guid employeeID = Guid.NewGuid();

        // Act
        Student student = new(studentID, "John", "Doe", "Nancy");
        Employee employee = new(employeeID, "John", "Williams", "Towner", 1, "Composer");
        entity.Add(student);

        // Assert
        Assert.IsTrue(entity.Contains(student));
        Assert.IsFalse(entity.Contains(employee));
    }
}