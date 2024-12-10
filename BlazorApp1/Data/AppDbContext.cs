using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Agente> Agentes { get; set; } = null!;
    public DbSet<Multa> Multas { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    }