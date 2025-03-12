using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowManager.Dominio.Features.Shows;

namespace ShowManager.Infra.Repository.Shows;

class ShowEntityConfiguration : IEntityTypeConfiguration<Show>
{
    public void Configure(EntityTypeBuilder<Show> builder)
    {
        builder.ToTable("Shows");
        builder.HasKey(o => o.Id);

        builder.Property(o => o.NomeShow)
            .HasMaxLength(200)
            .HasColumnType("nvarchar(200)")
            .IsRequired();

        builder.Property(o => o.DataInicio)
            .HasDefaultValue(new DateTime(2000, 1, 1))
            .HasColumnType("datetime2(0)")
            .IsRequired(false);

        builder.Property(o => o.DataFim)
            .HasDefaultValue(new DateTime(2000, 1, 1))
            .HasColumnType("datetime2(0)")
            .IsRequired(false);

        builder.Property(o => o.NumeroParticipantes)
            .HasDefaultValue(0)
            .HasColumnType("int")
            .IsRequired(false);

        builder.Property(o => o.Duracao)
            .HasDefaultValue(new TimeSpan(0))
            .HasColumnType("time")
            .IsRequired(false);

        //relacionamento

        builder.HasOne(s => s.Organizador)
            .WithMany(o => o.ListaShows)
            .HasForeignKey(s => s.OrganizadorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
