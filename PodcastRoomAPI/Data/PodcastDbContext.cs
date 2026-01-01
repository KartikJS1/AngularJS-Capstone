using Microsoft.EntityFrameworkCore;
using PodcastRoomAPI.Models;

namespace PodcastRoomAPI.Data
{
    public class PodcastDbContext: DbContext
    {
        public PodcastDbContext(DbContextOptions<PodcastDbContext> options): base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
    }
}
