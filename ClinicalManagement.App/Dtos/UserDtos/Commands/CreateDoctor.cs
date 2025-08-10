using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Dtos.UserDtos.Commands
{
   public   class CreateDoctor :UserDto
    {
       
        public string Role { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public string? Biography { get; set; }
    }
}
