using CR_Games_API___Domain.Entities.User;
using CR_Games_API___DTO.Request.Auth;
using CR_Games_API___DTO.Response.Auth;
using CR_Games_API___Infra.Repoitory.Interfaces;
using CR_Games_API___Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CR_Games_API___Service.Auth
{
    public class AuthService : IAuthService
    {
        #region Fields
        private readonly IBaseRepository<UserDomain> _baseRepository;
        private readonly JwtService _jwtService;
        #endregion

        #region Constructor
        public AuthService(
            IBaseRepository<UserDomain> baseRepository ,
            JwtService jwtService)
        {
            _baseRepository = baseRepository;
            _jwtService = jwtService;
        }
        #endregion

        #region Methods

        public async Task<AuthLoginResponseDTO> Auhenticate(AuthLoginRequestDTO request)
        {
            if (!string.IsNullOrEmpty(request.Email))
            {
                ValidateEmailFormat(request.Email);
            }
            else if (!string.IsNullOrEmpty(request.Cpf))
            {
                ValidatePasswordFormat(request.Cpf);
            }
            else
            {
                throw new Exception("Campo E-mail ou Cpf deve ser preenchido.");
            }

            ValidatePasswordFormat(request.Password);

            var user = await _baseRepository.Find(x => (x.Email == request.Email || x.Cpf == request.Cpf) && x.Password == request.Password);
            if (user != null)
            {
                if (user.Age < 18)
                {
                    throw new Exception("Usuario nao permitido. Apenas maiores de 18 anos podem acessar.");
                }

                return new AuthLoginResponseDTO
                {
                    UserId = user.Id,
                    Code = HttpStatusCode.OK,
                    Login = user.Email != null ? user.Email : user.Cpf,
                    IsSuccess = true,
                    Token = _jwtService.GenerateToken(user.Id.ToString(), user.Email != null ? user.Email : user.Cpf)
                };
            }

            else
            {
                throw new Exception("Usuario não localizado.");
            }
        }
        #region Private Methods
        private void ValidateEmailFormat(string email)
        {
            string[] provedoresPermitidos = { "@gmail.com, @outlook.com, @hotmail.com. @yahoo.com " };
            var isPermitted =provedoresPermitidos.Any(provedor => email.EndsWith(provedor, StringComparison.OrdinalIgnoreCase));

            if (isPermitted)
            {
                throw new Exception("O email deve ter um provedor permitido: @gmail.com, @outlook.com, @hotmail.com ou @yahoo.com.");
            }
            if (email.Length < 22)
            {
                throw new Exception("E-mail deve conter no minimo 12 caracteres.");
            }
        }

        private void ValidatePasswordFormat(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("A senha é obrigatória.");
            }

            if (password.Contains(" "))
            {
                throw new Exception("A senha nao pode conter um espaço em branco.");
            }

            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                throw new Exception("A senha deve conter uma letra maiuscula.");
            }

            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                throw new Exception("A senha deve conter uma letra minuscula.");
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                throw new Exception("A senha deve conter um numero.");
            }

            if (!Regex.IsMatch(password, @"[\W_]"))
            {
                throw new Exception("A senha deve conter um caracter especial.");
            }
        }

        private void ValidateCpfFormat(string CPF)
        {

            if (Regex.IsMatch(CPF, @"[\W_]"))
            {
                throw new Exception("CPF nao deve conter pontos ou espaços.");
            }

            if (!Regex.IsMatch(CPF, @"^[0-9X]{11}$"))
            {
                throw new Exception("CPF so pode conter a letra X e 11 digitos.");
            }
        }

        public Task<AuthLoginResponseDTO> Authenticate(AuthLoginRequestDTO request)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
