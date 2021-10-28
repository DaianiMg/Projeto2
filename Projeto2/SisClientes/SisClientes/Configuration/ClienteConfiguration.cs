using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisClientes.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
            .ToTable("cliente")
            .Property(e => e.Id)
            .HasColumnName("Id");

            builder.Property<int>("CidadeId").IsRequired();

            builder
               .HasOne(d => d.Cidade)
               .WithMany(p => p.Cliente)
               .HasForeignKey(d => d.CidadeId)
               .HasPrincipalKey(d => d.Id);

            builder
            .Property(c => c.Nome)
           .HasColumnName("Nome")
           .IsRequired()
           .HasColumnType("varchar(100)");

            builder
            .Property<DateTime>("Data_Nascimento")
            .HasColumnType("Data_Nascimento")
            .HasDefaultValueSql("getdate()")
            .IsRequired();

            builder
            .Property(c => c.Cep)
           .HasColumnName("Cep")
           .IsRequired()
           .HasColumnType("varchar(10)");

            builder
            .Property(c => c.Logradouro)
           .HasColumnName("Logradouro")
           //.IsRequired()
           .HasColumnType("varchar(100)");
            
            builder
            .Property(c => c.Bairro)
           .HasColumnName("Bairro")
           //.IsRequired()
           .HasColumnType("varchar(50)");

            builder
            .HasOne(d => d.Cidade)
            .WithMany(p => p.Cliente)
            .HasForeignKey(d => d.CidadeId)
            .HasPrincipalKey(d => d.Id);
        }
    }
}
