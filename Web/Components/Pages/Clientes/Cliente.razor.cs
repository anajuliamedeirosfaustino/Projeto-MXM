using Web.Services.Clientes;
using Web.Model;

namespace Web;

public partial class Cliente
{
    public class ClienteCode
    {
        private readonly IClienteService _clienteService;
        public ClienteCode(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public string Nome { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public string Cnpj { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public bool IsValid { get; set; } = false;

        public List<ClienteModel> ListCliente { get; set; }

        public ClienteModel ClienteModel { get; set; }

        public async Task HandleSubmit()
        {
            if(string.IsNullOrEmpty(Cpf))
            {
                ListCliente = await _clienteService.GetAllClientes();
            }
            else 
            {
                ClienteModel = await _clienteService.GetClientByCpf(Cpf.Trim());
            }
        }

        public async void DeleteClientByCpf(string cpf) 
        {
            await _clienteService.DeleteClientByCpf(cpf);
        }

    }
}

