using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScaeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaeApp.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente> 
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //chave primária
            builder.HasKey(c => c.Id);

            //mapeamento dos campos
            builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Cpf).HasMaxLength(15).IsRequired();
            builder.Property(c => c.Telefone).HasMaxLength(11).IsRequired();
            builder.Property(c => c.CadastradoEm).IsRequired();
            builder.Property(c => c.UltimaAtualizacaoEm).IsRequired();
        }
    }
}
