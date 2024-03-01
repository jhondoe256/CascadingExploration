using CascadeExploration.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascadeExploration.Models.ArtistModels
{
    public class ArtistCreate
    {
        [Required]
        [MinLength(1), MaxLength(100)]
        public string Name { get; set; }
    }
}
