using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcquisitionTermProject.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string IMDBUrl { get; set; }
        public double MovieRate { get; set; }

    }
}
