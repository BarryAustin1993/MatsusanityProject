using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Matsusanity.Models
{
    public class PersonalTrainersClients
    {

        [Key, Column(Order = 0)]
        public int PersonalTrainerId { get; set; }

        [Key, Column(Order = 1)]
        public int ClientId { get; set; }
    }
}
