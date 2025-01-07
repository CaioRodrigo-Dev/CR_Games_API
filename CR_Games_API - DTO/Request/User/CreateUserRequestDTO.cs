using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___DTO.Request.User
{
    public class CreateUserRequestDTO
    {

        [Required(ErrorMessage = "É NECESSARIO INFORMAR A IDADE DO USUARIO NO MOMENTO DO CADASTRO.")]
        public int Idade { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11)]
        [MinLength(10)]
        public string Cpf { get; set; }

        [MaxLength(120)]
        [MinLength(4)]
        public string Endereco { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
