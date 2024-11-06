using Domain.Entities;

namespace Application.Dtos
{
    public class EnderecoDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
