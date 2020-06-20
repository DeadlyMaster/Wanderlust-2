using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wanderlust.Services.API.Models
{
    public class Journey
    {
        [Key]
        public int JourneyId { get; set; }
        public string JourneyName { get; set; }

        public List<Sight> Sights { get; set; }

        public int User { get; set; }
    }
}
