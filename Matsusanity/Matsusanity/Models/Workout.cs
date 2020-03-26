using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Matsusanity.Models
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("WorkoutPlan")]
        public int? WorkoutPlanId { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }

        public string ExerciseOne { get; set; }
        public string RepsOne { get; set; }
        public string SetsOne { get; set; }
        public string WeightOne { get; set; }

        public string ExerciseTwo { get; set; }
        public string RepsTwo { get; set; }
        public string SetsTwo { get; set; }
        public string WeightTwo { get; set; }

        public string ExerciseThree { get; set; }
        public string RepsThree { get; set; }
        public string SetsThree { get; set; }
        public string WeightThree { get; set; }

        public string ExerciseFour { get; set; }
        public string RepsFour { get; set; }
        public string SetsFour { get; set; }
        public string WeightFour { get; set; }

        public string ExerciseFive { get; set; }
        public string RepsFive { get; set; }
        public string SetsFive { get; set; }
        public string WeightFive { get; set; }
    }
}
