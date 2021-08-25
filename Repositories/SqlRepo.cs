using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public class SqlRepo : IItemsRepository
    {
        private readonly ItemContext _context;

        public SqlRepo(ItemContext context)
        {
            _context = context;
        }
        public IEnumerable<Item> GetItems()
        {
            return _context.item.ToList();
        }
        public Item GetItem(Guid id)
        {
            return _context.item.FirstOrDefault(p => p.Id == id);
        }
        public void CreateItem(Item item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.item.Add(item);

        }


        public void DeleteItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _context.item.Remove(item);
                
        }

        public void UpdateItem(Item item)
        {
            //nothing 
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
