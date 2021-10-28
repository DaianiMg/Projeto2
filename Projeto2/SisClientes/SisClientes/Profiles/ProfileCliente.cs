using AutoMapper;
using SisClientes.Date.ClienteDto;
using SisClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisClientes.Profiles
{
    public class ProfileCliente :  Profile
    {
        public ProfileCliente()
        {
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<Cliente, ReadClienteDto>();
            CreateMap<UpdateClienteDto, Cliente>();
        }
    }
}
