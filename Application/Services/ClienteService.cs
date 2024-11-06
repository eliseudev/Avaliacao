using Application.Dtos;
using Application.Interfaces;
using Application.Mapper;
using Application.Validation;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoService _enderecoService;

        public ClienteService(IClienteRepository clienteRepository, IEnderecoService enderecoService)
        {
            _clienteRepository = clienteRepository;
            _enderecoService = enderecoService;
        }

        public async Task<ClienteDto> ClienteById(int id)
        {
            var result = await _clienteRepository.ClienteById(id);
            var cliente = new Map().MapClienteToDto(result);
            return cliente;
        }

        public void Create(ClienteDto cliente)
        {
            var clienteMap = new Map().MapDtoToCliente(cliente);

            if(clienteMap.Cpf.Length != 11) throw new ValidarDados("CPF inválido");

            cliente.Cpf = RemoverMascaraCpf(cliente.Cpf);

            var cpfValido = IsValidCpf(cliente.Cpf);

            if (!cpfValido) throw new ValidarDados("CPF inválido");

            var novoCliente = _clienteRepository.Create(clienteMap).Result;
            
            foreach (var endereco in cliente.Enderecos)
            {
                endereco.ClienteId = novoCliente;
                _enderecoService.Create(endereco);
            }
        }

        public void Delete(int id)
        {
            _enderecoService.Delete(id);
            _clienteRepository.Delete(id);
        }

        public async Task<IEnumerable<ClienteDto>> ListAll()
        {
            var list = await _clienteRepository.ListAll();
            var clientes = new Map().MapClientesToDtos(list);
            return clientes;
        }

        public async void Update(ClienteDto cliente)
        {
            Cliente updateCliente = new Cliente();
            updateCliente.Enderecos = new List<Endereco>();

            if (cliente.Cpf.Length != 11) throw new ValidarDados("CPF inválido");

            cliente.Cpf = RemoverMascaraCpf(cliente.Cpf);

            var cpfValido = IsValidCpf(cliente.Cpf);

            if (!cpfValido) throw new ValidarDados("CPF inválido");

            var map = new Map().MapDtoToCliente(cliente);

            _clienteRepository.Update(map);

            foreach (var endereco in cliente.Enderecos)
            {
                _enderecoService.Update(endereco);
            }
        }

        public bool IsValidCpf(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], cpf.Length) == cpf)
                return false;

            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var soma1 = 0;

            for (int i = 0; i < 9; i++)
                soma1 += int.Parse(cpf[i].ToString()) * multiplicador1[i];

            var resto1 = soma1 % 11;
            var digito1 = resto1 < 2 ? 0 : 11 - resto1;

            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var soma2 = 0;

            for (int i = 0; i < 10; i++)
                soma2 += int.Parse(cpf[i].ToString()) * multiplicador2[i];

            var resto2 = soma2 % 11;
            var digito2 = resto2 < 2 ? 0 : 11 - resto2;

            return cpf.EndsWith(digito1.ToString() + digito2.ToString());
        }

        private string RemoverMascaraCpf(string cpf)
        {
            return cpf = cpf.Replace(".", "").Replace("-", "");
        }

    }
}
