using ContaBancoApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ContaBancoApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<ContaBancaria> contasBancarias { get; set; }

    public DbSet<Agencia> agencias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Agencia>()
            .HasMany(a => a.ContasBancarias)
            .WithOne(c => c.Agencia)
            .HasForeignKey(c => c.AgenciaId);

    }

}