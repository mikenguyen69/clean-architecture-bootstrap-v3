using clean.architecture.core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace clean.architecture.integration.test.Data
{
    public class ToDoItemRepositoryShould : BaseRepositorySetup<ToDoItem>
    {
        [Fact]
        public void AddItemAndSetId()
        {
            var item = AddItemWithInitialTitle();

            var newItem = _repository.List().FirstOrDefault();

            Assert.Equal(item, newItem);
            Assert.True(newItem.Id > 0);

        }

        [Fact]
        public void UpdateItemAfterAddingIt()
        {
            var item = AddItemWithInitialTitle();

            _dbContext.Entry(item).State = EntityState.Detached;

            var newItem = _repository.List().FirstOrDefault();
            newItem.Title = Guid.NewGuid().ToString();
            _repository.Update(newItem);

            Assert.Equal(item.Id, newItem.Id);
            Assert.NotEqual(item.Title, newItem.Title);
        }

        [Fact]
        public void DeleteItemAfterAddingIt()
        {
            var item = AddItemWithInitialTitle();

            _repository.Delete(item);

            var existingItem = _repository.List().FirstOrDefault();

            Assert.True(existingItem == null);

        }

        [Fact]
        public void GetItemByIdAfterAddingIt()
        {
            var item = AddItemWithInitialTitle();
            var existingItem = _repository.GetById(item.Id);

            Assert.Equal(item.Title, existingItem.Title);
        }

        #region Helper
        private ToDoItem AddItemWithInitialTitle()
        {
            var initialTitle = Guid.NewGuid().ToString();
            var item = new ToDoItem()
            {
                Title = initialTitle
            };
            _repository.Add(item);

            return item;
        }
        #endregion

    }
}
