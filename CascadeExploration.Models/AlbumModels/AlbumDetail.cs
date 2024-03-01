using CascadeExploration.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CascadeExploration.Models.TrackModels;
using CascadeExploration.Models.ArtistModels;

namespace CascadeExploration.Models.AlbumModels
{
    public class AlbumDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ArtistListItem Artist { get; set; }
        public string Genre { get; set; }
        public DateTime Released { get; set; }
        public List<TrackListItem> Tracks { get; set; } = new List<TrackListItem>();
    }
}
