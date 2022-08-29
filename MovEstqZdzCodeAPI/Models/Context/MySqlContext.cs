using Microsoft.EntityFrameworkCore;

namespace MovEstqZdzCodeAPI.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext() {}
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) {}

        public DbSet<ItemMovEstoque> ItemMovEstoque { get; set; }
        public DbSet<EmpPes> EmpPes { get; set; }
        public DbSet<MovEstoque> MovEstoque { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}
