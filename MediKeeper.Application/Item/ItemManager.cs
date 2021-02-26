using System.Collections.Generic;
using System.Linq;

namespace MediKeeper.Application.Item
{
    public class ItemManager : IItemManager
    {
        private readonly IItemRepository _itemRepository;

        public ItemManager(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        
        public Domain.Item GetItem(int id)
        {
            return _itemRepository.GetItemById(id);
        }

        public IEnumerable<Domain.Item> GetItems()
        {
            return _itemRepository.GetAllItems();
        }

        public IEnumerable<Domain.Item> GetItemsWithMaxPriceOnly()
        {
            var allItems = _itemRepository.GetAllItems();

            var maxPricedItems = allItems
                .GroupBy(s => s.Name)
                .Select(g => g.First(d => d.Cost == g.Max(x => x.Cost))).ToList();

            return maxPricedItems;
        }

        public Domain.Item GetItemWithMaxPrice(string name)
        {
            var nameFilteredCollection = _itemRepository.GetItemsByName(name);
            return nameFilteredCollection.OrderBy(i => i.Cost).LastOrDefault();
        }


        public bool AddItem(Domain.Item newItem)
        {
            _itemRepository.AddItem(newItem);
            return _itemRepository.SaveAll();
        }

        public bool Delete(Domain.Item oldItem)
        {
            _itemRepository.Delete(oldItem);
            return _itemRepository.SaveAll();
        }

        public bool UpdateItem(Domain.Item item)
        {
            _itemRepository.UpdateItem(item);
            return _itemRepository.SaveAll();
        }
    }
}