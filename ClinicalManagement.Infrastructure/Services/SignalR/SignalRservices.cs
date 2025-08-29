using ClinicalManagement.Application.Abstractions;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services.SignalR
{
    public class SignalRservices : Hub
    {

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Recieve message" + $"{Context.ConnectionId}");
            //return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
