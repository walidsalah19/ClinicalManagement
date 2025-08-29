using ClinicalManagement.Application.Abstractions.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services.SignalR
{
    public class ConnectionMappingService : IConnectionMappingService
    {
        private readonly Dictionary<string, List<string>> _connections = new();

        public void AddConnection(string userId, string connectionId)
        {
            lock (_connections)
            {
                if (!_connections.ContainsKey(userId))
                    _connections[userId] = new List<string>();

                _connections[userId].Add(connectionId);
            }
        }

        public void RemoveConnection(string userId, string connectionId)
        {
            lock (_connections)
            {
                if (_connections.ContainsKey(userId))
                {
                    _connections[userId].Remove(connectionId);
                    if (_connections[userId].Count == 0)
                        _connections.Remove(userId);
                }
            }
        }

        public List<string> GetConnections(string userId)
        {
            return _connections.ContainsKey(userId) ? _connections[userId] : new List<string>();
        }
    }
}
