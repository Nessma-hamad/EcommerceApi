﻿using AngularApi.DTO;
using AngularApi.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Mapper
{
    
    public  class Mapperconfig

    {
        public static IMapper mapp { get; set; }

       static Mapperconfig()
        {
              var config = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Product, ProductDto>().ReverseMap();
                cfg.CreateMap<Category, CategoryDto>().ReverseMap();

            });

             mapp = config.CreateMapper();
        }



    }
}
