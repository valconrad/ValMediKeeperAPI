using System.Linq;
using MediKeeper.Application.Item;
using MediKeeper.Test.UnitTest.Fakes;
using Moq;
using Xunit;

namespace MediKeeper.Test.UnitTest
{
    public class ItemManagerOrderingTests
    {

        private readonly Mock<IItemRepository> _itemsRepository = new Mock<IItemRepository>();
        

        [Fact]
        public void WhenCalling_ItemManager_GetItemWithMaxPrice_ReturnsItem()
        {
            const string itemName = "ITEM5";
            var items = ItemsCollectionFake.GetGroupingItemsCollection()
                .Where(v => v.Name == itemName).ToList();
            _itemsRepository.Setup(x => x.GetItemsByName(It.IsAny<string>()))
                .Returns(items);

            var itemManager = new ItemManager(_itemsRepository.Object);

            var outputItem = itemManager.GetItemWithMaxPrice(itemName);

            Assert.NotNull(outputItem);
            Assert.Equal(455.01m, outputItem.Cost);
            Assert.Contains(outputItem, items);

            _itemsRepository.Verify(x => x.GetItemsByName(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void WhenCalling_ItemManager_GetItemWithMaxPrice_FromOnlyOneItemAvailable_ReturnsItem()
        {
            const string itemName = "ITEM1";
            var items = ItemsCollectionFake.GetAllUnorderedItemsCollection()
                .Where(v => v.Name == itemName).ToList();
            _itemsRepository.Setup(x => x.GetItemsByName(It.IsAny<string>()))
                .Returns(items);

            var itemManager = new ItemManager(_itemsRepository.Object);

            var outputItem = itemManager.GetItemWithMaxPrice(itemName);

            Assert.NotNull(outputItem);
            Assert.Equal(15.00m, outputItem.Cost);
            Assert.Single(items);
            Assert.Contains(outputItem, items);

            _itemsRepository.Verify(x => x.GetItemsByName(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void WhenCalling_ItemManager_GetItemsWithMaxPrice_ReturnsGroupedReducedCollection()
        {
            var items = ItemsCollectionFake.GetGroupingItemsCollection();
            _itemsRepository.Setup(x => x.GetAllItems()).Returns(items);

            var itemManager = new ItemManager(_itemsRepository.Object);

            var outputItems = itemManager.GetItemsWithMaxPriceOnly().ToList();

            Assert.NotNull(outputItems);
            Assert.Equal(7, outputItems.Count);

            Assert.Collection(outputItems,
                item =>
                {
                    Assert.Equal(3, item.Id); Assert.Equal(35.00m, item.Cost);
                },
                item =>
                {
                    Assert.Equal(4, item.Id); Assert.Equal(25.50m, item.Cost);
                },
                item =>
                {
                    Assert.Equal(7, item.Id); Assert.Equal(135.45m, item.Cost);
                },
                item =>
                {
                    Assert.Equal(8, item.Id); Assert.Equal(45.55m, item.Cost);
                },
                item =>
                {
                    Assert.Equal(12, item.Id); Assert.Equal(455.01m, item.Cost);
                },
                item =>
                {
                    Assert.Equal(14, item.Id); Assert.Equal(665.15m, item.Cost);
                },
                item =>
                {
                    Assert.Equal(15, item.Id); Assert.Equal(75.70m, item.Cost);
                });


            _itemsRepository.Verify(x => x.GetAllItems(), Times.Once);
        }
    }
}
