using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Dtos.UserDtos.Commands
{
   public   class CreateDoctor
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public string? Biography { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
