using CascadeExploration.Data.Entities;
using CascadeExploration.Data;
using CascadeExploration.Models.AlbumModels;
using CascadeExploration.Models.ArtistModels;
using CascadeExploration.Models.TrackModels;
using CascadeExploration.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CascadeExploration.Services.ArtistServices
{
    public  class ArtistService : IArtistService
    {
        private readonly ApplicationDbContext _context;

        public ArtistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddArtist(ArtistCreate model)
        {
            var entity = new Artist
            {
                Name = model.Name,
            };

            await _context.Artists.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null) return false;

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditArtist(ArtistEdit model)
        {
            var artist = await _context.Artists.FindAsync(model.Id);
            if (artist == null) return false;

            artist.Name = model.Name;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ArtistDetail> GetArtist(int id)
        {
            var artist =
                await
                _context.Artists
                .Include(a => a.Tracks).ThenInclude(t => t.Album)
                .Include(a => a.Albums)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (artist == null) return new ArtistDetail();

            return new ArtistDetail
            {
                Id = artist.Id,
                Name = artist.Name,
                Albums = artist.Albums.Select(a => new AlbumListItem
                {
                    Id = a.Id,
                    Genre = a.Genre,
                    Title = a.Title,
                    Released = a.Released,
                }).ToList(),
                Tracks = artist.Tracks.Select(a => new TrackListItem
                {
                    Id = a.Id,
                    Title = a.Title,
                    AlbumTitle = a.Album.Title,
                    Released = a.Released,

                }).ToList()

            };
        }

        public async Task<List<ArtistListItem>> GetArtists()
        {
            var artists = await _context.Artists.Select(a => new ArtistListItem
            {
                Id = a.Id,
                Name = a.Name,
            }).ToListAsync();

            return artists;
        }
    }
}
