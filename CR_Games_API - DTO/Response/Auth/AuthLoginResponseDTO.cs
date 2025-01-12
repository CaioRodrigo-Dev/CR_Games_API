using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___DTO.Response.Auth
{
    public class AuthLoginResponseDTO
    {
        public HttpStatusCode Code { get; set; }
        public bool IsSuccess { get; set; } 
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
    }
}
