using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wanderlust.Services.API.Models
{
    public class Landmark
    {
        //[Key]
        public int LandmarkId { get; set; }

        //[StringLength(100)]
        //[Required]
        public string LandmarkName { get; set; }

        //[StringLength(500)]
        public string LandmarkDescription { get; set; }

        //[Required]
        public string ImageUrl { get; set; }

        public bool MustSee { get; set; }
    }
}
