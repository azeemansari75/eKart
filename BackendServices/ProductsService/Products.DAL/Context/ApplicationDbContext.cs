using Microsoft.EntityFrameworkCore;
using Products.DAL.Entities;
using System.Data;

namespace Products.DAL.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
}
