using clean.architecture.core.Events;
using clean.architecture.core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace clean.architecture.core.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; protected set; }

        public void MarkComplete()
        {
            IsDone = true;
            Events.Add(new ToDoItemCompletedEvent(this));
        }
    }
}
