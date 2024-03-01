using CascadeExploration.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeExploration.Models.TrackModels
{
    public class TrackEdit
    {
        [Required]
        public int Id { get; set; }
       
        [Required]
        public int TrackNumber { get; set; }

        [Required]
        [MinLength(1), MaxLength(100)]
        public string Title { get; set; }

        
        [Required]
        public int ArtistId { get; set; }

        [Required]

        public int AlbumId { get; set; }

        public DateTime Released { get; set; }
    }
}
