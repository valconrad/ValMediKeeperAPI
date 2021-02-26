using System.Collections.Generic;

namespace MediKeeper.Application.Item
{
    public interface IItemManager
    {
        IEnumerable<Domain.Item> GetItems();
        IEnumerable<Domain.Item> GetItemsWithMaxPriceOnly();

        Domain.Item GetItemWithMaxPrice(string name);
        Domain.Item GetItem(int id);
        
        bool AddItem(Domain.Item newItem);
        bool UpdateItem(Domain.Item item);
        bool Delete(Domain.Item oldItem);
    }
}
