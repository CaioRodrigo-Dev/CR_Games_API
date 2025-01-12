using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___DTO.Request.Auth
{
    public class AuthLoginRequestDTO
    {
        #region Properties
        
        public string Email { get; set; }

        [Required(ErrorMessage = "O password é obrigatorio")]
        [MinLength(8, ErrorMessage = "O password deve conter no minimo 8 caracteres.")]
        public string Password { get; set; }

        public string Cpf { get; set; }
        #endregion
    }
}
