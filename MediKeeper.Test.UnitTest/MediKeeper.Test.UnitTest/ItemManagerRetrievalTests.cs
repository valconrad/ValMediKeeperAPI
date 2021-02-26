using System;
using System.Collections.Generic;
using System.Linq;
using MediKeeper.Application.Item;
using MediKeeper.Domain;
using MediKeeper.Test.UnitTest.Fakes;
using Moq;
using Xunit;

namespace MediKeeper.Test.UnitTest
{
    public class ItemManagerRetrievalTests
    {

        private readonly Mock<IItemRepository> _itemsRepository = new Mock<IItemRepository>();


        [Fact]
        public void WhenCalling_ItemManager_GetAllItems_ReturnsAllItems()
        {
            var items = ItemsCollectionFake.GetAllItemsCollection();
            _itemsRepository.Setup(x => x.GetAllItems()).Returns(items);

            var itemManager = new ItemManager(_itemsRepository.Object);

            var outputItems = itemManager.GetItems().ToList();

            Assert.NotNull(outputItems);
            Assert.Equal(7, outputItems.Count);
            Assert.Contains(items.First(x=>x.Id == 5), outputItems);

            _itemsRepository.Verify(x => x.GetAllItems(), Times.Once);
            Assert.Collection(outputItems,
                item => Assert.Equal(1, item.Id),
                item => Assert.Equal(2, item.Id),
                item => Assert.Equal(3, item.Id),
                item => Assert.Equal(4, item.Id),
                item => Assert.Equal(5, item.Id),
                item => Assert.Equal(6, item.Id),
                item => Assert.Equal(7, item.Id)
            );
        }

        [Fact]
        public void WhenCalling_ItemManager_GetAllItems_ReturnsEmptyList()
        {
            _itemsRepository.Setup(x => x.GetAllItems()).Returns(new List<Item>());

            var itemManager = new ItemManager(_itemsRepository.Object);

            var outputItems = itemManager.GetItems().ToList();

            Assert.NotNull(outputItems);
            Assert.Empty(outputItems);
            
            _itemsRepository.Verify(x => x.GetAllItems(), Times.Once);

        }

        [Fact]
        public void WhenCalling_ItemManager_GetAllItems_ExceptionThrown()
        {
            _itemsRepository.Setup(x => x.GetAllItems()).Throws(new ArgumentException());
            var itemManager = new ItemManager(_itemsRepository.Object);
            try
            {
                itemManager.GetItems();
            }
            catch (Exception ex)
            {
                Assert.IsType<ArgumentException>(ex);
            }
            _itemsRepository.Verify(x => x.GetAllItems(), Times.Once);
        }

        [Fact]
        public void WhenCalling_ItemManager_GetItemById_ReturnsItem()
        {
            var items = ItemsCollectionFake.GetAllItemsCollection();
            _itemsRepository.Setup(x => x.GetItemById(It.IsAny<int>()))
                .Returns(items.First(v=>v.Id == 5));

            var itemManager = new ItemManager(_itemsRepository.Object);

            var outputItem = itemManager.GetItem(5);

            Assert.NotNull(outputItem);
            Assert.Equal(5, outputItem.Id);
            Assert.Contains(outputItem, items);

            _itemsRepository.Verify(x => x.GetItemById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void WhenCalling_ItemManager_GetItemById_IsOutOfRange_ReturnsNullItem()
        {
            _itemsRepository.Setup(x => x.GetItemById(It.IsAny<int>())).Returns(null as Item);

            var itemManager = new ItemManager(_itemsRepository.Object);

            var outputItem = itemManager.GetItem(155);

            Assert.Null(outputItem);
            _itemsRepository.Verify(x => x.GetItemById(It.IsAny<int>()), Times.Once);
        }
    }
}
