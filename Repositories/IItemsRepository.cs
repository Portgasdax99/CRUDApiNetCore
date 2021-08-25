﻿using Catalog.Entities;
using System;
using System.Collections.Generic;

namespace Catalog.Repositories
{
    public interface IItemsRepository
    {
        bool SaveChange();
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Item item);
    }
}