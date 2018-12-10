using AspCore_Roles.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore_Roles.Data
{
  public class LeilaoDbContext : DbContext
  {
    public LeilaoDbContext(DbContextOptions<LeilaoDbContext> options) : base(options)
    {
    }

    public DbSet<Leilao> Leiloes { get; set; }
    public DbSet<Lance> Lances { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Leilao>().ToTable("Leilao");
      modelBuilder.Entity<Lance>().ToTable("Lance");
    }
  }
}
