

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowManager.Dominio.Features.Organizadores;

namespace ShowManager.Infra.Repository.Organizadores;

public class OrganizadorEntityConfiguration : IEntityTypeConfiguration<Organizador>
{
    public void Configure(EntityTypeBuilder<Organizador> builder)
    {
        builder.ToTable("Organizadores");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Apelido)
            .HasMaxLength(200)
            .HasColumnType("nvarchar(200)")
            .IsRequired();


        //relacionamneto q ja esta sendo feito ao contrario no shows

        //builder.HasMany(s => s.ListaShows)
        //    .WithOne(o => o.Organizador)
        //    .HasForeignKey(s => s.OrganizadorId);
            
    }
}
