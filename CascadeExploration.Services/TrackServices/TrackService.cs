using CascadeExploration.Data;
using CascadeExploration.Data.Entities;
using CascadeExploration.Models.AlbumModels;
using CascadeExploration.Models.ArtistModels;
using CascadeExploration.Models.TrackModels;
using CascadeExploration.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CascadeExploration.Services.TrackServices
{
    public class TrackService : ITrackService
    {
        private ApplicationDbContext _context;

        public TrackService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTrack(TrackCreate model)
        {
            var entity = new Track
            {
                ArtistId = model.ArtistId,
                TrackNumber = model.TrackNumber,
                AlbumId = model.AlbumId,
                Released = model.Released,
                Title = model.Title,
            };

            await _context.Tracks.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteTrack(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track == null) return false;

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditTrack(TrackEdit model)
        {
            var track = await _context.Tracks.FindAsync(model.Id);
            if (track == null) return false;

            track.ArtistId = model.ArtistId;
            track.TrackNumber = model.TrackNumber;
            track.AlbumId = model.AlbumId;
            track.Title = model.Title;
            track.Released = model.Released;
                
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TrackDetail> GetTrack(int id)
        {
            var track = await 
                _context
                .Tracks
                .Include(t=>t.Album)
                .Include(t=>t.Artist)
                .SingleOrDefaultAsync(x=>x.Id == id);

            if (track == null) return new TrackDetail();

            return new TrackDetail
            {
                Id = track.Id,
                Title = track.Title,
                Artist = new ArtistListItem 
                {
                    Id = track.Artist.Id,
                    Name = track.Artist.Name,
                },
                Album = new AlbumListItem 
                {
                    Id =track.Album.Id,
                    Title=track.Album.Title,
                    Genre = track.Album.Genre,
                    Released = track.Album.Released,
                }

            };
        }

        public async Task<List<TrackListItem>> GetTracks() 
        {
            var tracks = await _context.Tracks.Include(t=>t.Album).Select(t => new TrackListItem
            {
                Id=t.Id,
                Title = t.Title,
                AlbumTitle = t.Album.Title,
                ArtistName = t.Artist.Name,
                TrackNumber = t.TrackNumber,
                Released = t.Released
            }).ToListAsync();

            return tracks;
        }
        
    }
}
