using BlazorWebApp.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<FileEntity> Files { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
