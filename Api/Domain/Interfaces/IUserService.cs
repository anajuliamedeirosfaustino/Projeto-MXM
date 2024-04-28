using Api.Domain.Models;

namespace Api.Domain.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetAllUser();

    Task<UserModel> GetUserById(int id);

    Task AddUserModel(UserModel usermodel);

    Task UpdateUserModel(UserModel usermodel, int id);

    Task DeleteUserModel(int id);

    Task<UserModel> GetUserByCpf(string Cpf);

    Task<UserModel> GetUserByCnpj(string Cnpj);

    Task DeleteUserModel(string cpf);
}
