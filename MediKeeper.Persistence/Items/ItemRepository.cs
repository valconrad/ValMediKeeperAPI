using System.Collections.Generic;
using System.Linq;
using MediKeeper.Application.Item;
using MediKeeper.Domain;

namespace MediKeeper.Persistence.Items
{
    public class ItemRepository : IItemRepository
    {
        private readonly MediKeeperDbContext _ctx;

        public ItemRepository(MediKeeperDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddItem(Item item)
        {
            _ctx.Add(item);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _ctx.Items.OrderBy(i => i.Id).ToList();
        }

        public Item GetMaxPriceByName(string name)
        {
            return _ctx.Items.Where(i => i.Name == name).OrderBy(i => i.Cost).LastOrDefault();
        }



        public Item GetItemById(int id)
        {
            return _ctx.Items.FirstOrDefault(i => i.Id == id);
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void Delete(Item item)
        {
            _ctx.Remove(item);
        }

        public void UpdateItem(Item item)
        {
            var existing = _ctx.Items.First(x => x.Id == item.Id);
            existing.Name = item.Name;
            existing.Cost = item.Cost;
        }

        public IEnumerable<Item> GetItemsByName(string name)
        {
            return _ctx.Items.Where(i => i.Name == name).ToList();
        }
    }
}

