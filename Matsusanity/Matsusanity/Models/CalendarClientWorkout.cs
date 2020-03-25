using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Matsusanity.Models
{
    public class CalendarClientWorkout
    {
        [Key, Column(Order = 0)]
        public int ClientId { get; set; }
        
        [Key, Column(Order = 1)]
        public int WorkoutId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        [Display(Name = "All day event?")]
        public bool AllDay { get; set; }


    }
}
