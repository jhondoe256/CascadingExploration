using CascadeExploration.Models.AlbumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeExploration.Services.Contracts
{
    public interface IAlbumService
    {
        Task<bool> AddAlbum(AlbumCreate model);
        Task<bool> DeleteAlbum(int id);
        Task<bool> EditAlbum(AlbumEdit model);
        Task<List<AlbumListItem>> GetAlbums();
        Task<AlbumDetail> GetAlbum(int id);
    }
}
