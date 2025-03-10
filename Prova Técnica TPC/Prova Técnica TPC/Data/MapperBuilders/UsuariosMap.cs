using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaTecnicaTPC.Models.Entities;

namespace ProvaTecnicaTPC.Data.MapperBuilders
{
    public class UsuariosMap : IEntityTypeConfiguration<UsuariosEntity>
    {
        public void Configure(EntityTypeBuilder<UsuariosEntity> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(p => p.Id);

            builder.HasIndex(e => e.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("INTEGER")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(80)");

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(80)");

            builder.HasMany(e => e.Tarefas)
                .WithOne()
                .HasForeignKey(f => f.IdUsuario);


        }
    }
}
