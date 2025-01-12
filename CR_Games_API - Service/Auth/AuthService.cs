using CR_Games_API___Domain.Entities.User;
using CR_Games_API___Infra.Repoitory.Interfaces;
using CR_Games_API___Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        #endregion
        #endregion
    }
}
