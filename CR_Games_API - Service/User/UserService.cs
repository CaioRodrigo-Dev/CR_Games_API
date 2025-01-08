using CR_Games_API___Domain.Entities.User;
using CR_Games_API___DTO.Request.User;
using CR_Games_API___DTO.Response.User;
using CR_Games_API___Infra.Repoitory.Interfaces;
using CR_Games_API___Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CR_Games_API___Service.User
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly IBaseRepository<UserDomain> _baseRepository;
        #endregion

        #region Constructor
        public UserService(
            IBaseRepository<UserDomain> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods

        public async Task<CreateUserResponseDTO> CreateUser(CreateUserRequestDTO request)
        {
            if (!string.IsNullOrEmpty(request.Email))
            {
                ValidateEmailRequestDTO(request.Email);
            }
            if (!string.IsNullOrEmpty(request.Cpf))
            {
                ValidateCPFFormat(request.Cpf);
            }
            else
            {
                throw new Exception("Campo e-mail e CPF deve ser preenchido.");
            }

            ValidateAge(request.Age);
            ValidatePasswordRequestDTO(request.Password);

            var existingUser = await _baseRepository.Find(x => x.Email == request.Email || x.Cpf == request.Cpf);

            if (existingUser != null)
            {
                throw new Exception("Usuário com este e-mail ou CPF já existe.");
            }
            else
            {
                var user = new UserDomain
                {
                    Name = request.Name,
                    Age = request.Age,
                    Email = request.Email,
                    Password = request.Password,
                    Address = request.Address,
                    Cpf = request.Cpf
                };

                await _baseRepository.Insert(user);
            }

            return new CreateUserResponseDTO
            {
                CreatedAt = DateTime.UtcNow,
                IsCreated = true
            };
        }

        public async Task<GetUserByCpfResponseDTO> GetUserByCpf(GetUserByCpfRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Cpf))
                throw new Exception("O nome não pode ser vazio.");

            var getUser = await _baseRepository.Find(x => x.Cpf == request.Cpf);

            if (getUser == null)
                throw new Exception("Usuário não localizado.");

            return new GetUserByCpfResponseDTO
            {
                Name = getUser.Name,
                Age = getUser.Age,
                Cpf = request.Cpf,
                Email = getUser.Email,

            };
        }

        public async Task<DeleteUserResponseDTO> DeleteUser(DeleteUserRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Cpf))
                throw new Exception("O CPF não pode ser nulo ou vazio.");
            else
            {
                ValidateCPFFormat(request.Cpf);
            }

            var deletedUser = await _baseRepository.Find(x => x.Cpf == request.Cpf);

            if (deletedUser == null)
                throw new Exception("Usuário não encontrado com o CPF especificado.");

            await _baseRepository.Delete(deletedUser);

            throw new Exception($"Usuario {request.Cpf} deletado com sucesso.");
        }

        public async Task<UpdateUserResponseDTO> UpdateUser(UpdateUserRequestDTO request)
        {
            var user = await _baseRepository.Find(x => x.Cpf == request.Cpf);

            if (user == null)
                throw new Exception("Usuário não localizado.");

            user.Name = request.Name ?? user.Name;
            user.Email = request.Email ?? user.Email;
            user.Address = request.Address ?? user.Address;
            user.UpdatedDate = DateTime.Now;

            await _baseRepository.Update(user);

            return new UpdateUserResponseDTO
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                UpdatedAt = user.UpdatedDate
            };
        }

        public async Task<List<GetUserResponseDTO>> GetAllUsers()
        {
            {
                var users = await _baseRepository.GetAllUsers();

                var userDtos = users.Select(user => new GetUserResponseDTO
                {
                    Cpf = user.Cpf,
                    Name = user.Name,
                    Age = user.Age,
                    Email = user.Email,

                }).ToList();

                return userDtos;
            }
        }

        public async Task<List<GetUserResponseDTO>> GetAllUsersByName(GetUserRequestDTO request)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new Exception("O nome não pode ser vazio.");

            var userList = await _baseRepository.FindAll(x => x.Name.ToLower().Contains(request.Name.ToLower()));

            if (userList == null || !userList.Any())
                throw new Exception("Usuário não localizado.");

            var listUserResponseDTO = userList.Select(user => new GetUserResponseDTO
            {
                Name = user.Name,
                Age = user.Age,
                Email = user.Email,
                Cpf = user.Cpf
            }).ToList();

            return listUserResponseDTO;
        }
        public async Task<DeleteUserByIdResponseDTO> DeleteUserById(DeleteUserByIdRequestDTO request)
        {
            if (request.Id <= 0)
                throw new Exception("O campo não pode ser nulo ou vazio.");

            var deletedUser = await _baseRepository.Find(x => x.Id == request.Id);

            if (deletedUser == null)
                throw new Exception("Usuário não encontrado com o CPF especificado.");

            await _baseRepository.Delete(deletedUser);

            throw new Exception($"Usuario {request.Id} deletado com sucesso.");
        }

        public async Task DeleteAllUsers()
        {
            await _baseRepository.DeleteAllUsers();
        }

        public async Task<bool> ChangePassword(ChangePasswordRequestDTO request)
        {
            var user = await _baseRepository.Find(x => x.Email == request.Email);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            if (user.Password != request.CurrentPassword)
            {
                throw new Exception("Senha atual incorreta.");
            }

            ValidatePasswordRequestDTO(request.NewPassword);

            user.Password = request.NewPassword;
            await _baseRepository.Update(user);

            return true;
        }

        #region Private Methods
        private void ValidateEmailRequestDTO(string email)
        {
            string[] provedoresPermitidos = { "@gmail.com", "@outlook.com", "@hotmail.com", "@yahoo.com" };

            var isPermitted = provedoresPermitidos.Any(provedor => email.EndsWith(provedor, StringComparison.OrdinalIgnoreCase));

            if (!isPermitted)
            {
                throw new Exception("The email must contain an allowed provider: @gmail.com, @outlook.com, @hotmail.com, @yahoo.com");
            }

            if (email.Length < 12)
            {
                throw new Exception("The email must contain at least 12 characters");
            }
        }

        private void ValidatePasswordRequestDTO(string password)
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

        private void ValidateCPFFormat(string CPF)
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

        private void ValidateAge(int Idade)
        {
            if (Idade < 18)
            {
                throw new Exception("Cadastro não permitido. Permitido somente para maiores de 18 anos.");
            }
        }
        #endregion

        #endregion

    }
}
