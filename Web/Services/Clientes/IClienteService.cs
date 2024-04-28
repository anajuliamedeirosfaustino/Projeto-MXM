using Web.Model;

namespace Web.Services.Clientes;

public interface IClienteService
{
    public Task<List<ClienteModel>> GetAllClientes();

    public Task<ClienteModel>GetClientByCpf(string cpf);

    public Task DeleteClientByCpf(string cpf);
}
