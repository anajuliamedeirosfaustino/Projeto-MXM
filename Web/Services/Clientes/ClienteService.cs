using Newtonsoft.Json;
using Web.Model;

namespace Web.Services.Clientes;

public class ClienteService : IClienteService
{
    private static readonly HttpClient httpClient = new HttpClient();

    public async Task<List<ClienteModel>> GetAllClientes()
    {
        string url = $"http://localhost:5205/api/users";

        try
        {
            var result = await httpClient.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ClienteModel>>(json);
            }

            return Array.Empty<ClienteModel>().ToList();

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao consultar os usuários:", ex.Message);
            return Array.Empty<ClienteModel>().ToList();
        }
    }

    public async Task<ClienteModel> GetClientByCpf(string cpf) {
        string url = $"http://localhost:5205/api/user/cpf/{cpf}";

        try
        {
            var result = await httpClient.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ClienteModel>(json);
            }

            throw new Exception("Erro ao consultar usuário por cpf");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao consultar o cpf:", ex.Message);
            throw new Exception("Erro ao consultar usuário por cpf");
        }
    }

    public async Task DeleteClientByCpf(string cpf)
    {
        string url = $"http://localhost:5205/api/user/{cpf}";

        try
        {
            var result = await httpClient.DeleteAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
            }

            throw new Exception("Erro ao deletar usuário por cpf");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao deletar o cpf:", ex.Message);
            throw new Exception("Erro ao deletar usuário por cpf");
        }
    }

}
