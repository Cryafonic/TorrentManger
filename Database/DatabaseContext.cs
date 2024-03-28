using Microsoft.EntityFrameworkCore;
using TorrentManager.Database.Models;

namespace TorrentManager.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base(options) 
        { 
            
        }

        public DbSet<MediaRequestModel> MediaRequests { get; set; }
    }
}
