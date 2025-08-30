using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Common.Events.Notifications
{
    public record SendNotification(string message,string UserId) :INotification
    {
       
    }
}
