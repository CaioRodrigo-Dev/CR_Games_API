﻿using CR_Games_API___Domain.Entities.Game;
using CR_Games_API___DTO.Request.Games;
using CR_Games_API___DTO.Response.Games;
using CR_Games_API___Infra.Repoitory.Interfaces;
using CR_Games_API___Service.Auth;
using CR_Games_API___Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___Service.Games
{
    public class GamesService : IGamesService
    {
        #region Fields
        private readonly IBaseRepository<GameDomain> _baseRepository;
        private readonly JwtService _jwtService;
        #endregion

        #region Constructor
        public GamesService(
            IBaseRepository<GameDomain> baseRepository,
            JwtService jwtService)
        {
            _baseRepository = baseRepository;
            _jwtService = jwtService;
        }
        #endregion

        #region Methods
        public async Task<AddGameResponseDTO> AddGame(AddGameRequestDTO request)
        {
            ValidateStringField(request.Title, "O titulo do jogo é obrigatorio.");
            ValidateStringField(request.Description, "É obrigatório que o jogo tenha uma breve descrição para os usuarios.");
            ValidateDecimalField(request.Price, "É obrigatorio inserir o preço do jogo.");
            ValidateStringField(request.Plataform, "Informe a plataforma do jogo que esta sendo adicionado.");
            ValidateIntFiel(request.StockQuantity, "É necessario informar a quantidade de jogos que estão sendo adicionados ao sistema");

            //if (string.IsNullOrEmpty(request.Title))
            //{
            //    throw new Exception("O titulo do jogo é obirgatorio");
            //}
            //if (string.IsNullOrEmpty(request.Description))
            //{
            //    throw new Exception("É obrigatorio que o jogo tenha uma breve decrição para os usuarios.");
            //}
            //if ((request.Price <= 0))
            //{
            //    throw new Exception("É obrigatorio inserir o preço do jogo.");
            //}
            //if (string.IsNullOrEmpty(request.Plataform))
            //{
            //    throw new Exception("Informe a plataforma do jogo que esta sendo adicionado ao sistema.");
            //}
            //if (request.StockQuantity <= 0)
            //{
            //    throw new Exception("È necessario informar a quantidade de jogos que estão sendo adicionados no sistema.");
            //}

            var existingGame = await _baseRepository.Find(x => x.Title == request.Title);
            if (existingGame != null)
            {
                throw new Exception("Titulo do jogo ja cadastrado no banco de dados, atualize somente a quantidade em estoque.");
            }

            else
            {
                var game = new GameDomain
                {
                    Title = request.Title,
                    Description = request.Description,
                    Price = request.Price,
                    Plataform = request.Plataform,
                    StockQuantity = request.StockQuantity,
                };
                await _baseRepository.Insert(game);
            }

            return new AddGameResponseDTO
            {
                CreatedAt = DateTime.UtcNow,
                IsCreated = true,
            };
        }

        public async Task<GetGameByIdResponseDTO> GetGameById(GetGameByIdRequestDTO request)
        {
            if (request == null)

                throw new Exception("O Id nao pode ser nulo ou vazio.");

            var gameId = await _baseRepository.Find(x => x.Id == request.Id);

            if (gameId == null)
                throw new Exception("Game com o Id especificado não encontrado");

            return new GetGameByIdResponseDTO
            {
                Title = gameId.Title,
                Description = gameId.Description,
                Price = gameId.Price,
                Plataform = gameId.Plataform,
                StockQuantity = gameId.StockQuantity,
            };

        }

        public async Task DeleteGameById(DeleteGameByIdRequestDTO request)
        {
            if (request == null)
                throw new Exception("O Id do game a ser deletado nao pode ser nulo.");

            var gameId = await _baseRepository.Find(x => x.Id == request.Id);

            if (gameId == null)
                throw new Exception("Id nao encontrado no sistema");

            await _baseRepository.Delete(gameId);
            throw new Exception($"Game com o Id {request.Id} deletado com sucesso");
        }

        public async Task<UpdateGameResponseDTO> UpdateGame(UpdateGameRequestDTO request)
        {
            var game = await _baseRepository.Find(x => x.Id == request.Id);
            if (game == null)
                throw new Exception("Id nao localizado.");

            game.Title = request.Title ?? game.Title;
            game.StockQuantity = request.StockQuantity ?? game.StockQuantity;
            game.Plataform = request.Plataform ?? game.Plataform;
            game.Price = request.Price ?? game.Price;

            await _baseRepository.Update(game);

            return new UpdateGameResponseDTO
            {
                Title = game.Title,
                StockQuantity = game.StockQuantity,
                Plataform = game.Plataform,
                Price = game.Price,
                UpdatedAt = game.UpdatedDate,

            };
        }

        #region Private Methods
        private void ValidateStringField(string request, string errorMessage)
        {
            if (string.IsNullOrEmpty(request))
            {
                throw new Exception(errorMessage);
            }
        }

        private void ValidateDecimalField(decimal request, string errorMessage)
        {
            if (request <= 0)
            {
                throw new Exception(errorMessage);
            }
        }

        private void ValidateIntFiel(int request, string errorMessage)
        {
            if (request <= 0)
            {
                throw new Exception(errorMessage);
            }
        }
        #endregion
        #endregion
    }
}
