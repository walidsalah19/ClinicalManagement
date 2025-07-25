﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Domain.Models
{
   public class Prescription
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        public ICollection<PrescriptionItem> Items { get; set; }
    }
}
