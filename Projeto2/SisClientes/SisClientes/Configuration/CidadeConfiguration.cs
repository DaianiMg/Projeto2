using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisClientes.Configuration
{
    internal class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {

        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder
                .ToTable("cidade");

            builder
                .Property(c => c.Id)
                .HasColumnName("Id");

            builder
                .Property(c => c.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(c => c.Estado)
                .HasColumnName("Estado")
                .IsRequired()
                .HasColumnType("varchar(60)");
            

        }
    }
}