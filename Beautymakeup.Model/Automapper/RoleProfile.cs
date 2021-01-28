using AutoMapper;
using Beautymakeup.Core.Entitys;
using Beautymakeup.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beautymakeup.Model.Automapper
{
  public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleViewModel, Role>();
        }

    }
}
