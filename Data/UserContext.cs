namespace WebApi.Helpers;

using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class UserContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public UserContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server database
        options.UseSqlServer(Configuration.GetConnectionString("Default"));
    }

    public DbSet<User> Users { get; set; }
}