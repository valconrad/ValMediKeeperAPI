using System;
using MediKeeper.Application.Item;
using MediKeeper.Domain;
using Moq;
using Xunit;

namespace MediKeeper.Test.UnitTest
{
    public class ItemManagerCrudTests
    {

        private readonly Mock<IItemRepository> _itemsRepository = new Mock<IItemRepository>();

        [Fact]
        public void WhenCalling_ItemManager_AddItem_ReturnsSuccess()
        {
            var item = new Item { Name = "Item100", Cost = 300.55m};
            _itemsRepository.Setup(x => x.AddItem(It.IsAny<Item>()));
            _itemsRepository.Setup(x => x.SaveAll()).Returns(true);

            var itemManager = new ItemManager(_itemsRepository.Object);

            var isAdded = itemManager.AddItem(item);

            Assert.True(isAdded);
            

            _itemsRepository.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Once);
            _itemsRepository.Verify(x => x.SaveAll(), Times.Once);
        }

        [Fact]
        public void WhenCalling_ItemManager_AddItem_ReturnsFailure()
        {
            var item = new Item { Name = "Item100", Cost = 300.55m };
            _itemsRepository.Setup(x => x.AddItem(It.IsAny<Item>()));
            _itemsRepository.Setup(x => x.SaveAll()).Returns(false);

            var itemManager = new ItemManager(_itemsRepository.Object);

            var isAdded = itemManager.AddItem(item);

            Assert.False(isAdded);
            _itemsRepository.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Once);
            _itemsRepository.Verify(x => x.SaveAll(), Times.Once);
        }

        [Fact]
        public void WhenCalling_ItemManager_AddItem_RaisedException()
        {
            var item = new Item { Name = "Item100", Cost = 300.55m };
            _itemsRepository.Setup(x => x.AddItem(It.IsAny<Item>())).Throws(new AccessViolationException());


            var itemManager = new ItemManager(_itemsRepository.Object);
            try
            {
                itemManager.AddItem(item);
            }
            catch (Exception e)
            {
                Assert.IsType<AccessViolationException>(e);
                
            }
            _itemsRepository.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Once);

        }

        [Fact]
        public void WhenCalling_ItemManager_UpdateItem_ReturnsSuccess()
        {
            var item = new Item { Name = "Item100", Cost = 300.55m };
            _itemsRepository.Setup(x => x.UpdateItem(It.IsAny<Item>()));
            _itemsRepository.Setup(x => x.SaveAll()).Returns(true);

            var itemManager = new ItemManager(_itemsRepository.Object);

            var isSuccess = itemManager.UpdateItem(item);

            Assert.True(isSuccess);

            _itemsRepository.Verify(x => x.UpdateItem(It.IsAny<Item>()), Times.Once);
            _itemsRepository.Verify(x => x.SaveAll(), Times.Once);
        }

        [Fact]
        public void WhenCalling_ItemManager_UpdateItem_ReturnsFailure()
        {
            var item = new Item { Name = "Item100", Cost = 300.55m };
            _itemsRepository.Setup(x => x.UpdateItem(It.IsAny<Item>()));
            _itemsRepository.Setup(x => x.SaveAll()).Returns(false);

            var itemManager = new ItemManager(_itemsRepository.Object);

            var isSuccess = itemManager.UpdateItem(item);

            Assert.False(isSuccess);

            _itemsRepository.Verify(x => x.UpdateItem(It.IsAny<Item>()), Times.Once);
            _itemsRepository.Verify(x => x.SaveAll(), Times.Once);
        }

        [Fact]
        public void WhenCalling_ItemManager_UpdateItem_ExceptionThrown()
        {
            var item = new Item { Name = "Item100", Cost = 300.55m };
            _itemsRepository.Setup(x => x.AddItem(It.IsAny<Item>()));
            _itemsRepository.Setup(x => x.SaveAll()).Throws(new AccessViolationException());

            var itemManager = new ItemManager(_itemsRepository.Object);
            try
            {
                itemManager.UpdateItem(item);
            }
            catch (Exception e)
            {
                Assert.IsType<AccessViolationException>(e);

            }
            _itemsRepository.Verify(x => x.UpdateItem(It.IsAny<Item>()), Times.Once);
            _itemsRepository.Verify(x => x.SaveAll(), Times.Once);
        }


        [Fact]
        public void WhenCalling_ItemManager_DeletesItem_ReturnsSuccess()
        {
            var item = new Item { Name = "Item100", Cost = 300.55m };
            _itemsRepository.Setup(x => x.Delete(It.IsAny<Item>()));
            _itemsRepository.Setup(x => x.SaveAll()).Returns(true);

            var itemManager = new ItemManager(_itemsRepository.Object);

            var isSuccess = itemManager.Delete(item);

            Assert.True(isSuccess);

            _itemsRepository.Verify(x => x.Delete(It.IsAny<Item>()), Times.Once);
            _itemsRepository.Verify(x => x.SaveAll(), Times.Once);
        }

        [Fact]
        public void WhenCalling_ItemManager_DeletesItem_ReturnsFailure()
        {
            var item = new Item { Name = "Item100", Cost = 300.55m };
            _itemsRepository.Setup(x => x.UpdateItem(It.IsAny<Item>()));
            _itemsRepository.Setup(x => x.SaveAll()).Returns(false);

            var itemManager = new ItemManager(_itemsRepository.Object);

            var isSuccess = itemManager.Delete(item);

            Assert.False(isSuccess);

            _itemsRepository.Verify(x => x.Delete(It.IsAny<Item>()), Times.Once);
            _itemsRepository.Verify(x => x.SaveAll(), Times.Once);
        }

        [Fact]
        public void WhenCalling_ItemManager_DeletesItem_ExceptionThrown()
        {
            var item = new Item { Name = "Item100", Cost = 300.55m };
            _itemsRepository.Setup(x => x.Delete(It.IsAny<Item>()));
            _itemsRepository.Setup(x => x.SaveAll()).Throws(new AccessViolationException());

            var itemManager = new ItemManager(_itemsRepository.Object);
            try
            {
                itemManager.Delete(item);
            }
            catch (Exception e)
            {
                Assert.IsType<AccessViolationException>(e);

            }
            _itemsRepository.Verify(x => x.Delete(It.IsAny<Item>()), Times.Once);
            _itemsRepository.Verify(x => x.SaveAll(), Times.Once);
        }
    }
}
