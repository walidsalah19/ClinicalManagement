using ClinicalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Models
{
   public class Notification
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }

        public string UserId { get; set; }
        public UserModel User { get; set; }
    }
}
