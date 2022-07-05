using Microsoft.EntityFrameworkCore;

namespace PlayGroundV2.Shared
{
    public class PlayGroundContext : DbContext
    {
        public PlayGroundContext(DbContextOptions<PlayGroundContext> options)
        : base(options)
        {
        }

        public DbSet<Tasks.Task> Tasks { get; set; }
    }
}
