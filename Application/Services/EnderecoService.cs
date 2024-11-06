using Application.Dtos;
using Application.Interfaces;
using Application.Mapper;
using Domain.Interfaces;

namespace Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRespository _enderecoRepository;

        public EnderecoService(IEnderecoRespository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public void Create(EnderecoDto endereco)
        {
            var map = new Map().MapDtoToEndereco(endereco);
            _enderecoRepository.Create(map);
        }

        public void Delete(int Id)
        {
            _enderecoRepository.Delete(Id);
        }

        public async void Update(EnderecoDto endereco)
        {
            var updateEndereco = new Map().MapDtoToEndereco(endereco);
            _enderecoRepository.Update(updateEndereco);
        }
    }
}
