using clean.architecture.core.Entities;
using clean.architecture.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clean.architecture.api.Models
{
    public static class SeedData
    {
        public static void EnsureDataPopuldated(AppDbContext context)
        {
            if (!context.ToDoItems.Any())
            {
                context.ToDoItems.AddRange(
                    new ToDoItem
                    {
                        Id = 1,
                        Title = "Test Item 1",
                        Description = "Description 1"
                    },
                    new ToDoItem
                    {
                        Id = 2,
                        Title = "Test Item 2",
                        Description = "Description 2"
                    }
                );
            }
        }
    }
}
