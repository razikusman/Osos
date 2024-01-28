using Microsoft.EntityFrameworkCore;

namespace UserManagement
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext( DbContextOptions<BookStoreContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Book> books { get; set; }
    }
}
