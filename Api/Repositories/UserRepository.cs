using System.Data;
using Api.Domain.Interfaces;
using Api.Domain.Models;
using Dapper;
using MySqlConnector;

namespace Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BancoMxm");
        }
        public async Task<IEnumerable<UserModel>> GetAllUser()
        {
            using IDbConnection db = new MySqlConnection(_connectionString);
            var result = await db.QueryAsync<UserModel>("SELECT * FROM projetomxm.cadastro");
            return result;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            using IDbConnection db = new MySqlConnection(_connectionString);
            return await db.QueryFirstOrDefaultAsync<UserModel>("SELECT * FROM projetomxm.cadastro WHERE Id = @Id", new { Id = id });
        }

        public async Task<UserModel> GetUserByCpf(string Cpf)
        {
            using IDbConnection db = new MySqlConnection(_connectionString);
            return await db.QueryFirstOrDefaultAsync<UserModel>("SELECT * FROM projetomxm.cadastro WHERE Cpf = @Cpf", new { Cpf = Cpf });
        }

        public async Task<UserModel> GetUserByCnpj(string Cnpj)
        {
            using IDbConnection db = new MySqlConnection(_connectionString);
            return await db.QueryFirstOrDefaultAsync<UserModel>("SELECT * FROM projetomxm.cadastro WHERE Cnpj = @Cnpj", new { Cnpj = Cnpj });
        }

        public async Task AddUserModel(UserModel usermodel)
        {
            using IDbConnection db = new MySqlConnection(_connectionString);
            string sql = @"INSERT INTO projetomxm.cadastro 
            (
                Nome, Cpf, Cnpj, Email, Telefone) 
                VALUES (@Nome, @Cpf, @Cnpj, @Email, @Telefone 
            )";

            await db.ExecuteAsync(sql, usermodel);
        }

        public async Task UpdateUserModel(UserModel usermodel, int id)
        {
            using IDbConnection db = new MySqlConnection(_connectionString);
            string sql = @"UPDATE projetomxm.cadastro SET 
                Nome = @Nome, 
                Cpf = @Cpf,
                Cnpj = @Cnpj,
                Email = @Email,
                Telefone = @Telefone
                WHERE Cpf = @Cpf";


            await db.ExecuteAsync(sql, new
            {
                usermodel.Nome,
                usermodel.Cpf,
                usermodel.Cnpj,
                usermodel.Email,
                usermodel.Telefone,
                Id = id
            });
        }

        public async Task DeleteUserModel(int id)
        {
            using IDbConnection db = new MySqlConnection(_connectionString);
            string sql = "DELETE FROM projetomxm.cadastro WHERE Id = @Id";
            await db.ExecuteAsync(sql, new { Id = id });
        }

        public async Task DeleteUserModel(string cpf)
        {
            using IDbConnection db = new MySqlConnection(_connectionString);
            string sql = "DELETE FROM projetomxm.cadastro WHERE Cpf = @Cpf";
            await db.ExecuteAsync(sql, new { Cpf = cpf });
        }
    }
}
