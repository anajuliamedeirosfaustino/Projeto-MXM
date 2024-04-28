using Api.Domain.Interfaces;
using Api.Domain.Models;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUserModel(UserModel usermodel)
        {
            await _userRepository.AddUserModel(usermodel);
        }

        public async Task DeleteUserModel(int id)
        {
            await _userRepository.DeleteUserModel(id);
        }

        public async Task DeleteUserModel(string cpf)
        {
            await _userRepository.DeleteUserModel(cpf);
        }

        public async Task<IEnumerable<UserModel>> GetAllUser()
        {
            return await _userRepository.GetAllUser();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<UserModel> GetUserByCpf(string cpf)
        {
            return await _userRepository.GetUserByCpf(cpf);
        }

        public async Task<UserModel> GetUserByCnpj(string Cnpj)
        {
            return await _userRepository.GetUserByCnpj(Cnpj);
        }

        public async Task UpdateUserModel(UserModel usermodel, int id)
        {
            await _userRepository.UpdateUserModel(usermodel, id);
        }
    }
}