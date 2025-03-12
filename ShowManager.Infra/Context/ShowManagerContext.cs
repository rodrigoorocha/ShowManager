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

    public DbSet<Organizador> Organizadores { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShowManagerContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
