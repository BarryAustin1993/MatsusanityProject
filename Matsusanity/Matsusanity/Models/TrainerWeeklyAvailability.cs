using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Matsusanity.Models
{
    public class TrainerWeeklyAvailability
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("PersonalTrainer")]
        public string PersonalTrainerId { get; set; }
        public PersonalTrainer personalTrainer { get; set; }

        public DateTime MondayStartTime { get; set; }
        public DateTime MondayEndTime { get; set; }

        public DateTime TuesdayStartTime { get; set; }
        public DateTime TuesdayEndTime { get; set; }

        public DateTime WednesdayStartTime { get; set; }
        public DateTime WednesdayEndTime { get; set; }

        public DateTime ThursdayStartTime { get; set; }
        public DateTime ThursdayEndTime { get; set; }

        public DateTime FridayStartTime { get; set; }
        public DateTime FridayEndTime { get; set; }

        public DateTime SaturdayStartTime { get; set; }
        public DateTime SaturdayEndTime { get; set; }

        public DateTime SundayStartTime { get; set; }
        public DateTime SundayEndTime { get; set; }
    }
}
