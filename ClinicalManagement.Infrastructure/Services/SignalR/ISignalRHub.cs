using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions
{
    public interface ISignalRHub
    {
        public Task onSendMessagage(string message);
        public Task onSendNotification(string message);

    }
}
