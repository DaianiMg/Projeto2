using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SisProdutos.Date.DtosProduto;
using SisProdutos.Date.DtosUsuario;
using SisProdutos.Model;

namespace SisProdutos.Profilles
{
    public class Profille : Profile
    {
        public Profille()
        {
            CreateMap<CreateProdutoDto, Produtos>();
            CreateMap<Produtos, ReadProdutoDto>();
            CreateMap<UpdateProdutoDto, Produtos>();
            CreateMap<ListaProdutos, Produtos>();


            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();

        }
    }
}