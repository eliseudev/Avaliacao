using Application.Dtos;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        void Create(ClienteDto cliente);
        void Update(ClienteDto cliente);
        void Delete(int Id);
        Task<IEnumerable<ClienteDto>> ListAll();
        Task<ClienteDto> ClienteById(int Id);
    }
}
