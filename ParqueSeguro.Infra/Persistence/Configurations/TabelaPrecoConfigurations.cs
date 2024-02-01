using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Win32;
using ParqueSeguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Infra.Persistence.Configurations
{
    public class TabelaPrecoConfigurations : IEntityTypeConfiguration<TabelaPreco>
    {
        public void Configure(EntityTypeBuilder<TabelaPreco> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.DataInicio)
                .IsRequired();

            builder
                .Property(x => x.DataFinal)
                .IsRequired();

            builder
               .Property(x => x.ValorInicial)
               .HasPrecision(14, 2)
               .IsRequired();

            builder
                .Property(x => x.ValorAdicional)
                .HasPrecision(14, 2)
                .IsRequired();


        }
    }
}
