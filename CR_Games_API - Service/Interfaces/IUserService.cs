using CR_Games_API___DTO.Response.User;
using CR_Games_API___DTO.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CR_Games_API___Service.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserResponseDTO> CreateUser(CreateUserRequestDTO request);

        Task<GetUserByCpfResponseDTO> GetUserByCpf(GetUserByCpfRequestDTO request);
        Task<DeleteUserResponseDTO> DeleteUser(DeleteUserRequestDTO request);
        Task<UpdateUserResponseDTO> UpdateUser(UpdateUserRequestDTO request);
        Task<List<GetUserResponseDTO>> GetAllUsers();
        Task<List<GetUserResponseDTO>> GetAllUsersByName(GetUserRequestDTO request);
        Task<DeleteUserByIdResponseDTO> DeleteUserById(DeleteUserByIdRequestDTO request);
        Task DeleteAllUsers();
        Task<bool> ChangePassword(ChangePasswordRequestDTO request);
    }
}
