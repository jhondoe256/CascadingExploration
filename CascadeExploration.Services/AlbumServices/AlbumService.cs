using CascadeExploration.Data;
using CascadeExploration.Data.Entities;
using CascadeExploration.Models.AlbumModels;
using CascadeExploration.Models.ArtistModels;
using CascadeExploration.Models.TrackModels;
using CascadeExploration.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeExploration.Services.AlbumServices
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationDbContext _context;

        public AlbumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAlbum(AlbumCreate model)
        {
            var entity = new Album
            {
                ArtistId = model.ArtistId,
                Title = model.Title,
                Genre = model.Genre,
                Released = DateTime.Now,
            };

            await _context.Albums.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null) return false;
            
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> EditAlbum(AlbumEdit model)
        {
            var album = await _context.Albums.FindAsync(model.Id);
            if (album == null) return false;

            album.Title = model.Title;
            album.Genre = model.Genre;
            album.ArtistId = model.ArtistId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AlbumDetail> GetAlbum(int id)
        {
            var album = await 
                _context
                .Albums
                .Include(a=>a.Tracks)
                .Include(a=>a.Artist)
                .SingleOrDefaultAsync(x=> x.Id == id);

            if (album == null) return new AlbumDetail();

            return new AlbumDetail
            {
                Id = album.Id,
                Title = album.Title,
                Genre = album.Genre,
                Released = album.Released,
                Artist = new ArtistListItem 
                {
                    Id =album.Artist.Id,
                    Name = album.Artist.Name,
                },
                Tracks = album.Tracks.Select(x=> new TrackListItem { 
                    Id = x.Id,
                    TrackNumber = x.TrackNumber,
                    Title = x.Title,
                    Released=x.Released,
                    AlbumTitle = album.Title,
                    ArtistName = album.Artist.Name
                }).ToList()
            };
        }

        public async Task<List<AlbumListItem>> GetAlbums() => await _context.Albums.Select(a => new AlbumListItem
        {
           Id=a.Id,
           Genre=a.Genre,
           Title =a.Title,
           Released =a.Released
        }).ToListAsync();
    }
}
