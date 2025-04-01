using CR_Games_API___Domain.Entities.Console;
using CR_Games_API___DTO.Request.Console;
using CR_Games_API___DTO.Response.Console;
using CR_Games_API___Infra.Repoitory.Interfaces;
using CR_Games_API___Service.Auth;
using CR_Games_API___Service.Interfaces;

namespace CR_Games_API___Service.Console
{
    public class ConsolesService : IConsolesService
    {
        #region Fields
        private readonly IBaseRepository<ConsoleDomain> _baseRepository;
        private readonly JwtService _jwtService;
        #endregion

        #region Constructor
        public ConsolesService(
            IBaseRepository<ConsoleDomain> baseRepository,
            JwtService jwtService)
        {
            _baseRepository = baseRepository;
            _jwtService = jwtService;
        }

        #endregion

        #region Methods
        Task<AddConsoleResponseDTO> IConsolesService.AddConsole(AddConsoleRequestDTO request)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
