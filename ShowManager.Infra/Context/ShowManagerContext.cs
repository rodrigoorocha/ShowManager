using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Infra.Context;

public class ShowManagerContext : DbContext
{
    public ShowManagerContext(DbContextOptions<ShowManagerContext> options) : base(options)
    {

    }

    public DbSet<Organizador> Organizador { get; set; }
    public DbSet<Show> Show { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShowManagerContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
