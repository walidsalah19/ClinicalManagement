using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.UserDtos.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.UpdatePatient
{
   public class UpdatePatientCommand:IRequest<Result<string>>
    {
        public UpdatePatientDto patientDto { get; set; }
    }
}
