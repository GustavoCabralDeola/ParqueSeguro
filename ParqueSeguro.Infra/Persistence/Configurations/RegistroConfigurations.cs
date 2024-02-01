using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using ParqueSeguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Infra.Persistence.Configurations
{
    public class RegistroConfigurations : IEntityTypeConfiguration<Registro>
    {
        public void Configure(EntityTypeBuilder<Registro> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Placa)
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property(x => x.HoraChegada)
                .IsRequired();

            builder
                .Property(x => x.Preco)
                .HasPrecision(14, 2);

            builder
                .Property(x => x.Duracao)
                .HasConversion(new TimeSpanToTicksConverter());

            builder
                .Property(x => x.ValorPagar)
                .HasPrecision(14, 2);


        }
    }
}
