using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MvcMusicApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
  

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
           
        }

        public System.Data.Entity.DbSet<MvcMusicApp.Models.ToDo> ToDoes { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        // all context data
        // tables
    }
}