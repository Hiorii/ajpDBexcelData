using DbPerformance.Models;
using DbPerformance.Services;
using Microsoft.EntityFrameworkCore;

namespace DbPerformance.EntityFramework;

public class EfDbContext : DbContext
{
    
    public DbSet<ExcelDataModel> Kody { get; set; }  
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(DbServices.conn);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ExcelDataModel>(builder =>
        {
            builder.HasKey(option => new { option.Adres, option.Miejscowosc, option.Powiat, option.Wojewodztwo, option.KodPocztowy });
            builder.ToTable("Kody_Pocztowe");
        });
    }
}  