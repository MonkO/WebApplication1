using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebAppBL.Models;
using WebAppDAL.Entities;

namespace WebAppBL.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();
        }
    }
}
