﻿using AutoMapper;
using EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreBase.ViewModel;

namespace WebCoreBase.Automapper
{
    public class ViewModelAutoMapperConfig : Profile
    {
        public ViewModelAutoMapperConfig()
        {
            CreateMap<UsersView, User>().ForMember(dto => dto.Gender, source =>
            {
                source.MapFrom(m => m.Gender == "男" ? 1 : 0);
            }).AfterMap((dto, ent) => ent.Created = DateTime.Now);
            CreateMap<User, UsersView>().ForMember(dto => dto.Gender, source =>
            {
                source.MapFrom(m => m.Gender == 1 ? "男" : "女");
            });
        }
    }
}
