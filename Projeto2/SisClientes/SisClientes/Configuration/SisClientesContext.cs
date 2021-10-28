using Microsoft.EntityFrameworkCore;
using SisClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisClientes.Configuration
{
    public class SisClientesContext : DbContext
    {

        public SisClientesContext(DbContextOptions<SisClientesContext> opt) : base(opt)
        {
        }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<CidadesCliente> CidadesCliente { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Projeto1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
