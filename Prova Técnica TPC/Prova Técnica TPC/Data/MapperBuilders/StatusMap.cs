using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaTecnicaTPC.Models.Entities;

namespace ProvaTecnicaTPC.Data.MapperBuilders
{
    public class StatusMap : IEntityTypeConfiguration<StatusEntity>
    {
        public void Configure(EntityTypeBuilder<StatusEntity> builder)
        {
            builder.ToTable("Status");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("INTEGER")
                .ValueGeneratedNever();

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(45)");
        }
    }
}
