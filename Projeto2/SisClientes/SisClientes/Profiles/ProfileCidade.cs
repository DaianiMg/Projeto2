using AutoMapper;
using SisClientes.Date.CidadeDto;
using SisClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisClientes.Profiles
{
    public class ProfileCidade : Profile
    {
        public ProfileCidade()
        {
            CreateMap<CreateCidadeDto, Cidade>();
            CreateMap<Cidade, ReadCidadeDto>();
            CreateMap<UpdateCidadeDto, Cidade>();
        }
    }
}
