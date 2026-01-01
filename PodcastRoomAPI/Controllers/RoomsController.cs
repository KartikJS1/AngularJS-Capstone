using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PodcastRoomAPI.Data;
using PodcastRoomAPI.Models;

namespace PodcastRoomAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController: ControllerBase
    {
        private readonly PodcastDbContext _context;

        public RoomsController(PodcastDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            room.RoomCode = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return Ok(room);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            return Ok(await _context.Rooms.ToListAsync());
        }

        [HttpGet("{roomCode}")]
        public async Task<IActionResult> GetRoom(string roomCode)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomCode == roomCode);
            if(room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPut("{roomCode}")]
        public async Task<IActionResult> UpdateRoom(string roomCode, Room updatedRoom)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomCode == roomCode);
            if (room == null)
                return NotFound();


            room.RoomTitle = updatedRoom.RoomTitle;
            room.PodcastTitle = updatedRoom.PodcastTitle;
            room.AudioUrl = updatedRoom.AudioUrl;
            room.ThumbnailUrl = updatedRoom.ThumbnailUrl;
            room.Host = updatedRoom.Host;


            await _context.SaveChangesAsync();
            return Ok(room);
        }

        [HttpDelete("{roomCode}")]
        public async Task<IActionResult> DeleteRoom(string roomCode)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomCode == roomCode);
            if (room == null)
                return NotFound();


            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
