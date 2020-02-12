using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcquisitionTermProject.Models
{
    public class rate
    {
        public long movieId { get; set; }
        public int userBasedPrediction { get; set; }
        public int itemBasedPrediction { get; set; }
    }
}
