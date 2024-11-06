using System.Text.Json.Serialization;
using Domain.Entities;

namespace Application.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string UfNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<EnderecoDto> Enderecos { get; set; }
    }
}
