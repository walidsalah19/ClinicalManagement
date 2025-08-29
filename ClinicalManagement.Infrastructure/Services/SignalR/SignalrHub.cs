using ClinicalManagement.Application.Abstractions.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services.SignalR
{
    public class SignalrHub :Hub
    {
        private readonly IConnectionMappingService _connectionMappingService;

        public SignalrHub(IConnectionMappingService connectionMappingService)
        {
            _connectionMappingService = connectionMappingService;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("Welcome", Context.ConnectionId);

            var userId = Context.User?.FindFirst("sub")?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                _connectionMappingService.AddConnection(userId, Context.ConnectionId);
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.User?.FindFirst("sub")?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                _connectionMappingService.RemoveConnection(userId, Context.ConnectionId);
            }
            await base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessageToAll(string message)
        {
            await Clients.All.SendAsync("Alllah", message);
        }
    }
}
