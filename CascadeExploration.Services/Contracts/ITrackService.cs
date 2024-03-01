using CascadeExploration.Models.AlbumModels;
using CascadeExploration.Models.TrackModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeExploration.Services.Contracts
{
    public interface ITrackService
    {
        Task<bool> AddTrack(TrackCreate model);
        Task<bool> DeleteTrack(int id);
        Task<bool> EditTrack(TrackEdit model);
        Task<List<TrackListItem>> GetTracks();
        Task<TrackDetail> GetTrack(int id);
    }
}
