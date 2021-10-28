using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SisProdutos.Model;

namespace SisProdutos.Date
{
    public class UsuarioContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> opt) : base(opt)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Produtos> Produtos { get; set; }
    }
}
