using Catalog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> opt) : base(opt)
        {

        }

        public DbSet<Item> item { get; set; }
    }
}
