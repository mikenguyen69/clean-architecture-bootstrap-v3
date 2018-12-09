using System;
using System.Collections.Generic;
using System.Text;

namespace clean.architecture.core.SharedKernel
{
    public abstract class BaseDomainEvent
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.Now;
    }
}
