using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class BlockDeNotas : DbContext
    {
        public BlockDeNotas(DbContextOptions<BlockDeNotas> options) : base(options)
        {   
        }

        public DbSet<Nota> Notas { get; set; }

        public DbSet<User> Users { get; set; }
    }
}