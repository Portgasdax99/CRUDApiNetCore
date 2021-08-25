using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<CreateItemDto, Item>();
            CreateMap<UpdateItemDto, Item>();
            CreateMap<Item, UpdateItemDto>();   
        }
    }
}   
