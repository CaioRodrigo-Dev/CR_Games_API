using CR_Games_API___Domain.Entities.Accessory;
using CR_Games_API___Domain.Entities.Console;
using CR_Games_API___Domain.Entities.Game;
using CR_Games_API___Domain.Entities.Order;
using CR_Games_API___Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CR_Games_API___Infra.DBContext
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<UserDomain> Users { get; set; }
        public DbSet<GameDomain> Games { get; set; }
        public DbSet<ConsoleDomain> Consoles { get; set; }
        public DbSet<AccessoryDomain> Accessories { get; set; }
        public DbSet<OrderDomain> Orders { get; set; }
    }
}
