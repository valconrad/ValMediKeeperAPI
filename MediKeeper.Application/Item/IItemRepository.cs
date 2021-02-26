using System.Collections.Generic;

namespace MediKeeper.Application.Item
{
    public interface IItemRepository
    {
        IEnumerable<Domain.Item> GetAllItems();
        Domain.Item GetMaxPriceByName(string name);

        Domain.Item GetItemById(int id);
        IEnumerable<Domain.Item> GetItemsByName(string name);
        //IEnumerable<Item> GetItemsByMaxCost();


        bool SaveAll();
        void UpdateItem(Domain.Item model);
        void AddItem(Domain.Item newItem);
        void Delete(Domain.Item oldItem);
    }
}
