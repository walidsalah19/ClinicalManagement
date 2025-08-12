using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Dtos.AuthDtos
{
   public class TokenResponse
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
