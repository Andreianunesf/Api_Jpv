using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("TB_Pessoa");
            builder.HasKey(key => key.Id);
            builder.Property(col => col.Nome).HasMaxLength(70);
            builder.Property(col => col.CPF).HasMaxLength(11);
            builder.Property(col => col.Dt_Nascimento);
        }
    }
}
