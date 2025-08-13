using ClinicalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Models
{
   public class Doctor : UserModel
    {
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public string? Biography { get; set; }


       /* public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();*/
    }
}
