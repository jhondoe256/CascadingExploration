using CascadeExploration.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CascadeExploration.Models.ArtistModels;
using CascadeExploration.Models.AlbumModels;

namespace CascadeExploration.Models.TrackModels
{
    public class TrackListItem
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }
        public string Title { get; set; }
        public string  ArtistName{ get; set; }
        public string  AlbumTitle { get; set; }
        public DateTime Released { get; set; }
    }
}
