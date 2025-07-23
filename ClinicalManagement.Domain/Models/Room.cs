using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; } // كشف، عمليات، الخ...

        public ICollection<Appointment> Appointments { get; set; }
    }
}
