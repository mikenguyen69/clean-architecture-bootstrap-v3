using clean.architecture.core.Entities;
using clean.architecture.core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace clean.architecture.core.Events
{
    public class ToDoItemCompletedEvent : BaseDomainEvent
    {
        private ToDoItem completedItem; 

        public ToDoItemCompletedEvent(ToDoItem item)
        {
            completedItem = item;
        }
    }
}
