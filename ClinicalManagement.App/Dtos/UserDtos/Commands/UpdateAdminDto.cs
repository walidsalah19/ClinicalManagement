using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Dtos.UserDtos.Commands
{
    class UpdateAdminDto
    {
        private string AdminId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
       
        public string NationalId { get; set; }

    }
}
