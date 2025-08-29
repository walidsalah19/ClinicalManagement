using ClinicalManagement.Application.Abstractions;
using ClinicalManagement.Application.Abstractions.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services.SignalR
{
    public class SignalRservices:ISignalrServices
    {

        private readonly IHubContext<SignalrHub> _hubContext;
        private readonly IConnectionMappingService _connectionMappingService;

        public SignalRservices(IHubContext<SignalrHub> hubContext, IConnectionMappingService connectionMappingService)
        {
            _hubContext = hubContext;
            _connectionMappingService = connectionMappingService;
        }

        public async Task SendMessageToUserAsync(string userId, string message)
        {
            var connections = _connectionMappingService.GetConnections(userId);
            foreach (var connectionId in connections)
            {
                await _hubContext.Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
            }
        }
    }
}
