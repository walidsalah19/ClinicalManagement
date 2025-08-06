using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Entities
{
   public  class UsersModel: IdentityUser
    {
        public string Gender { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
       
    }
}
