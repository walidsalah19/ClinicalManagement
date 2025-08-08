using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Dtos.UserDtos.Queries
{
    public class PatientDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string NationalId { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Id { get; set; }


    }
}
