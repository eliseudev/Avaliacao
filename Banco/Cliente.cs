using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Customer.Banco;


public class Cliente
{

    public int Id { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public string UfNascimento { get; set; }
    public DateTime DataCadastro { get; set; }
    public List<Endereco> Enderecos { get; set; }
    
}