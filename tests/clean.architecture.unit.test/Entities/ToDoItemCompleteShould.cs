using clean.architecture.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using clean.architecture.core.Events;

namespace clean.architecture.unit.test.Entities
{
    public class ToDoItemCompleteShould
    {
        [Fact]
        public void MarkIsDoneToTrue()
        {
            ToDoItem item = new ToDoItem();
            item.MarkComplete();

            Assert.True(item.IsDone);
        }

        [Fact]
        public void AddToDoItemCompletedEvent()
        {
            ToDoItem item = new ToDoItem();
            item.MarkComplete();
            Assert.True(item.Events.Count(x => x.GetType() == typeof(ToDoItemCompletedEvent)) == 1);
        }
      
    }
}
