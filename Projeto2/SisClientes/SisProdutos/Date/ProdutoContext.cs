using Microsoft.EntityFrameworkCore;
using SisProdutos.Model;

namespace SisProdutos.Date
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> opt) : base(opt)
        {
        }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<CidadeResponse> CidadeResponse { get; set; }
    }
}
