using CascadeExploration.Data.Entities;
using CascadeExploration.Models.AlbumModels;
using CascadeExploration.Models.TrackModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeExploration.Models.ArtistModels
{
    public class ArtistDetail
    {
   
        public int Id { get; set; }

        public string Name { get; set; }

        public List<AlbumListItem> Albums { get; set; } = new List<AlbumListItem>();
        public List<TrackListItem> Tracks { get; set; } = new List<TrackListItem>();
    }
}
