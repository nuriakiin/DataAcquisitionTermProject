using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcquisitionTermProject.Models
{
    public class MovieRate
    {

        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public int Rate { get; set; }
    }
}
