using BenzodiazepineManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BenzodiazepineManagement.Infrastructure;

public class BenzodiazepineManagementDbContext : DbContext
{
    public BenzodiazepineManagementDbContext(
        DbContextOptions<BenzodiazepineManagementDbContext> options
    )
        : base(options) { }

    public DbSet<BenzodiazepineDbModel> Benzodiazepines { get; set; }

    public DbSet<ImageResourceDbModel> ImageResources { get; set; }

    public DbSet<PharmacologicalPropertyDbModel> PharmacologicalProperties { get; set; }

    public DbSet<UserActionDbModel> UserActions { get; set; }
}
