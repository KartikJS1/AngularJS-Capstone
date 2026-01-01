using System.ComponentModel.DataAnnotations;

namespace PodcastRoomAPI.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public string RoomCode { get; set; }

        [Required]
        public string RoomTitle { get; set; }

        [Required]
        public string PodcastTitle { get; set; }

        public string? AudioUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Host { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
