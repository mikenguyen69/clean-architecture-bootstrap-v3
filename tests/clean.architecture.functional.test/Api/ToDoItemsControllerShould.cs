using clean.architecture.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace clean.architecture.functional.test.Api
{
    public class ToDoItemsControllerShould : BaseWebControllerServiceTest<ToDoItem>
    {
        [Fact]
        public async Task ListShouldReturnTwoItems()
        {
            var result = (await GetList("/api/todoitems")).ToList();

            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.Count(x => x.Title == "Test Items 1"));
            Assert.Equal(1, result.Count(x => x.Title == "Test Items 2"));
        }
    }
}
