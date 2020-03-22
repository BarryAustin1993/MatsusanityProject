using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matsusanity.Models;
using Microsoft.AspNetCore.Identity;

namespace Matsusanity.ViewModels
{
    public class CreatePersonalTrainerViewModel
    {
        public PersonalTrainer PersonalTrainer { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public IdentityUserRole<string> IdentityUserRole { get; set; }
        public IdentityRole IdentityRole { get; set; }
    }
}
