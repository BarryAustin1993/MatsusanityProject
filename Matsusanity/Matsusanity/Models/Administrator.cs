using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Matsusanity.Models
{
    public class Administrator
    {
        public Administrator()
        {
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("IdentityUser")]
        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
