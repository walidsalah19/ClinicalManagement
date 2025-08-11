using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.UserDtos.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.User.AllAdmins
{
    public class AllAdminsQuery: IRequest<Result<List<AdminDto>>>
    {
    }
}
