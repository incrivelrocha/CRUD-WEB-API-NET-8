using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaTecnicaTPC.Models.Entities;

namespace ProvaTecnicaTPC.Data.MapperBuilders
{
    public class TarefasMap : IEntityTypeConfiguration<TarefasEntity>
    {
        public void Configure(EntityTypeBuilder<TarefasEntity> builder)
        {
            builder.ToTable("Tarefas");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("INTEGER")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("varchar(45)");

            builder.Property(p => p.DescricaoTarefa)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(150)");

            builder.Property(p => p.IdUsuario)
                .HasColumnName("IdUsuario")
                .HasColumnType("INT");

            builder.Property(p => p.IdStatus)
                .HasColumnName("IdStatus")
                .HasColumnType("INT");

            builder.HasOne(e => e.Status)
                .WithMany()
                .HasForeignKey(f => f.IdStatus);

        }
    }
}
