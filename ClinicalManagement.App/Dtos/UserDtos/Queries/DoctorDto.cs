using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Dtos.UserDtos.Queries
{
    public class DoctorDto : UserDto
    {
        public string Id { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public string? Biography { get; set; }
    }
}
