using Application.Dtos;

namespace Application.Interfaces
{
    public interface IEnderecoService
    {
        void Create(EnderecoDto endereco);
        void Update(EnderecoDto endereco);
        void Delete(int id);
    }
}
