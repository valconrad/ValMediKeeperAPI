using System.Collections.Generic;
using MediKeeper.Domain;

namespace MediKeeper.Test.UnitTest.Fakes
{
    public class ItemsCollectionFake
    {
        public static List<Item> GetAllItemsCollection()
        {
            var collection = new List<Item>()
            {
                new Item(){Id = 1, Name = "ITEM1", Cost = 15.00m},
                new Item(){Id = 2, Name = "ITEM2", Cost = 25.50m},
                new Item(){Id = 3, Name = "ITEM3", Cost = 35.45m},
                new Item(){Id = 4, Name = "ITEM4", Cost = 45.55m},
                new Item(){Id = 5, Name = "ITEM5", Cost = 55.01m},
                new Item(){Id = 6, Name = "ITEM6", Cost = 65.15m},
                new Item(){Id = 7, Name = "ITEM7", Cost = 75.70m},
            };

            return collection;
        }

        public static List<Item> GetGroupingItemsCollection()
        {
            var collection = new List<Item>()
            {
                new Item(){Id = 1, Name = "ITEM1", Cost = 15.00m},
                new Item(){Id = 2, Name = "ITEM1", Cost = 25.00m},
                new Item(){Id = 3, Name = "ITEM1", Cost = 35.00m},
                new Item(){Id = 4, Name = "ITEM2", Cost = 25.50m},
                new Item(){Id = 5, Name = "ITEM3", Cost = 75.45m},
                new Item(){Id = 6, Name = "ITEM3", Cost = 25.45m},
                new Item(){Id = 7, Name = "ITEM3", Cost = 135.45m},
                new Item(){Id = 8, Name = "ITEM4", Cost = 45.55m},
                new Item(){Id = 9, Name = "ITEM5", Cost = 155.01m},
                new Item(){Id = 10, Name = "ITEM5", Cost = 255.01m},
                new Item(){Id = 11, Name = "ITEM5", Cost = 355.01m},
                new Item(){Id = 12, Name = "ITEM5", Cost = 455.01m},
                new Item(){Id = 13, Name = "ITEM6", Cost = 65.15m},
                new Item(){Id = 14, Name = "ITEM6", Cost = 665.15m},
                new Item(){Id = 15, Name = "ITEM7", Cost = 75.70m},
            };

            return collection;
        }

        public static List<Item> GetAllUnorderedItemsCollection()
        {
            var collection = new List<Item>()
            {
                new Item(){Id = 4, Name = "ITEM5", Cost = 45.55m},
                new Item(){Id = 1, Name = "ITEM1", Cost = 15.00m},
                new Item(){Id = 7, Name = "ITEM7", Cost = 75.70m},
                new Item(){Id = 3, Name = "ITEM5", Cost = 35.45m},
                new Item(){Id = 6, Name = "ITEM6", Cost = 65.15m},
                new Item(){Id = 5, Name = "ITEM5", Cost = 55.01m},
                new Item(){Id = 2, Name = "ITEM2", Cost = 25.50m},
            };

            return collection;
        }
    }
}
