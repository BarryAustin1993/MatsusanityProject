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
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        [Key, Column(Order = 1)]
        public string WorkoutId { get; set; }
        public virtual Workout Workout { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
