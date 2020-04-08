using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Matsusanity.Models
{
    public class InSessionRequest
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PersonalTrainer")]
        public int PersonalTrainerId { get; set; }
        public PersonalTrainer PersonalTrainer { get; set; }


        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public bool? Approved { get; set; }

        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "All Day Event?")]
        public bool AllDay { get; set; }

        public string Url { get; set; }

    }
}
