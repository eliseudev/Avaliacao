using Application.Dtos;
using Domain.Entities;

namespace Application.Mapper
{
    public class Map
    {
        public ClienteDto MapClienteToDto(Cliente cliente)
        {
            if (cliente is null) return null;

            return new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DataNascimento = cliente.DataNascimento,
                UfNascimento = cliente.UfNascimento,
                DataCadastro = cliente.DataCadastro,
                Enderecos = cliente.Enderecos.Select(MapEnderecoToDto).ToList()
            };
        }

        public Cliente MapDtoToCliente(ClienteDto clienteDto)
        {
            return new Cliente
            {
                Id = clienteDto.Id,
                Nome = clienteDto.Nome,
                Cpf = clienteDto.Cpf,
                DataNascimento = clienteDto.DataNascimento,
                UfNascimento = clienteDto.UfNascimento,
                DataCadastro = clienteDto.DataCadastro,
                Enderecos = clienteDto.Enderecos.Select(MapDtoToEndereco).ToList()
            };
        }

        public EnderecoDto MapEnderecoToDto(Endereco endereco)
        {
            return new EnderecoDto
            {
                Id = endereco.Id,
                ClienteId = endereco.ClienteId,
                Logradouro = endereco.Logradouro,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Uf = endereco.Uf,
                DataCadastro = endereco.DataCadastro,
            };
        }

        public Endereco MapDtoToEndereco(EnderecoDto enderecoDto)
        {
            return new Endereco
            {
                Id = enderecoDto.Id,
                ClienteId = enderecoDto.ClienteId,
                Logradouro = enderecoDto.Logradouro,
                Bairro = enderecoDto.Bairro,
                Cidade = enderecoDto.Cidade,
                Uf = enderecoDto.Uf,
                DataCadastro = enderecoDto.DataCadastro,
            };
        }

        public IEnumerable<Endereco> MapDtosToEnderecos(IEnumerable<EnderecoDto> enderecoDtos)
        {
            return enderecoDtos.Select(enderecoDto => new Endereco
            {
                Id = enderecoDto.Id,
                ClienteId = enderecoDto.ClienteId,
                Logradouro = enderecoDto.Logradouro,
                Bairro = enderecoDto.Bairro,
                Cidade = enderecoDto.Cidade,
                Uf = enderecoDto.Uf,
                DataCadastro = enderecoDto.DataCadastro,
            }).ToList();
        }


        public IEnumerable<ClienteDto> MapClientesToDtos(IEnumerable<Cliente> clientes)
        {
            return clientes.Select(cliente => new ClienteDto
            {
                Id = cliente.Id,
                Cpf = cliente.Cpf,
                Nome = cliente.Nome,
                DataNascimento = cliente.DataNascimento,
                UfNascimento = cliente.UfNascimento,
                DataCadastro = cliente.DataCadastro,
                Enderecos = cliente.Enderecos.Select(endereco => new EnderecoDto
                {
                    Id = endereco.Id,
                    ClienteId = endereco.ClienteId,
                    Logradouro = endereco.Logradouro,
                    Bairro = endereco.Bairro,
                    Cidade = endereco.Cidade,
                    Uf = endereco.Uf,
                    DataCadastro = endereco.DataCadastro,
                }).ToList()
            }).ToList();
        }

        public IEnumerable<Cliente> MapDtosToClientes(IEnumerable<ClienteDto> clientes)
        {
            return clientes.Select(cliente => new Cliente
            {
                Id = cliente.Id,
                Cpf = cliente.Cpf,
                Nome = cliente.Nome,
                DataNascimento = cliente.DataNascimento,
                UfNascimento = cliente.UfNascimento,
                DataCadastro = cliente.DataCadastro,
                Enderecos = cliente.Enderecos.Select(endereco => new Endereco
                {
                    Id = endereco.Id,
                    ClienteId = endereco.ClienteId,
                    Logradouro = endereco.Logradouro,
                    Bairro = endereco.Bairro,
                    Cidade = endereco.Cidade,
                    Uf = endereco.Uf,
                    DataCadastro = endereco.DataCadastro,
                }).ToList()
            }).ToList();
        }
    }
}
