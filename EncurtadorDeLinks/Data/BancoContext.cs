using EncurtadorDeLinks.Models;
using Microsoft.EntityFrameworkCore;

namespace EncurtadorDeLinks.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<LinkModel> Links { get; set; }
    }
}
