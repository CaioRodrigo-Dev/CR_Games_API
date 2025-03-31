//using CR_Games_API___Domain.Entities.Game;
//using CR_Games_API___DTO.Request.Games;
//using CR_Games_API___DTO.Response.Games;
//using CR_Games_API___Infra.Repoitory.Interfaces;
//using CR_Games_API___Service.Auth;
//using CR_Games_API___Service.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CR_Games_API___Service.Console
//{
//    public class ConsolesService : IConsolesService
//    {
//        #region Fields
//        private readonly IBaseRepository<ConsoleDomain> _baseRepository;
//        private readonly JwtService _jwtService;
//        #endregion

//        #region Constructor
//        public ConsolesService(
//            IBaseRepository<ConsoleDomain> baseRepository,
//            JwtService jwtService)
//        {
//            _baseRepository = baseRepository;
//            _jwtService = jwtService;
//        }
//        #endregion

//        #region Methods
//        public async Task<AddConsoleResponseDTO> AddConsole(AddConsoleRequestDTO request)
//        {
//            if (string.IsNullOrEmpty(request.Model))
//            {
//                throw new Exception("O modelo do console é obirgatorio");
//            }
//            if (string.IsNullOrEmpty(request.Description))
//            {
//                throw new Exception("É obrigatorio que o jogo tenha uma breve decrição para os usuarios.");
//            }
//            if ((request.Price <= 0))
//            {
//                throw new Exception("É obrigatorio inserir o preço do console.");
//            }
//            if (string.IsNullOrEmpty(request.Developer))
//            {
//                throw new Exception("Informe o desenvolvedor do console que esta sendo adicionado ao sistema.");
//            }
//            if (request.StockQuantity <= 0)
//            {
//                throw new Exception("È necessario informar a quantidade de consoles que estão sendo adicionados no sistema.");
//            }

//            var existingConsole = await _baseRepository.Find(x => x.Model == request.Model);
//            if (existingConsole != null)
//            {
//                throw new Exception("O modelo do console ja está cadastrado no banco de dados, atualize somente a quantidade em estoque.");
//            }

//            else
//            {
//                var console = new ConsoleDomain
//                {
//                    Title = request.Title,
//                    Description = request.Description,
//                    Price = request.Price,
//                    Plataform = request.Plataform,
//                    StockQuantity = request.StockQuantity,
//                };
//                await _baseRepository.Insert(console);
//            }

//            return new AddConsoleResponseDTO
//            {
//                CreatedAt = DateTime.UtcNow,
//                IsCreated = true,
//            };
//        }
//    }
//}
