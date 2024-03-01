using CascadeExploration.Models.AlbumModels;
using CascadeExploration.Models.ArtistModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeExploration.Services.Contracts
{
    public interface IArtistService
    {
        Task<bool> AddArtist(ArtistCreate model);
        Task<bool> DeleteArtist(int id);
        Task<bool> EditArtist(ArtistEdit model);
        Task<List<ArtistListItem>> GetArtists();
        Task<ArtistDetail> GetArtist(int id);
    }
}
