using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.NotificationsDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Notifications
{
   public class GetNotifications:IRequest<Result<List<NotifyDto>>>
    {
        public required string Id { get; set; }
    }
}
