using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.SignalR
{
    public interface ISignalrServices
    {
        public Task SendMessageToUserAsync(string userId, string message);
    }
}
