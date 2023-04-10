using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Models;
using Xunit;

namespace ToDoAPI.Tests
{
  public class ToDoItemModelTests
  {
    [Fact]
    public void CanChangeName()
    {
      var testToDoItem = new ToDoItem
      {
        Name = "Some Todo Item"
      };

      testToDoItem.Name = "Some New Todo";

      Assert.Equal("Some New Todo", testToDoItem.Name);
    }
  }
}