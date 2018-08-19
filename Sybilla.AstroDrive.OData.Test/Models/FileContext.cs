using Microsoft.EntityFrameworkCore;

namespace OData.Models
{
    public partial class FileContext : DbContext
    {
        public FileContext()
        {
        }

        public FileContext(DbContextOptions<FileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<File> Files { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>(entity => { });
        }
    }
}
