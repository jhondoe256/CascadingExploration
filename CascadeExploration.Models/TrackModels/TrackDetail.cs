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
    public class TrackDetail
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }
        
        public ArtistListItem Artist { get; set; }
       
        public AlbumListItem Album { get; set; }
        public DateTime Released { get; set; }
    }
}
