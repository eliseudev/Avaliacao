using System.Text.Json.Serialization;

namespace Customer.Banco;


public class Endereco
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Uf { get; set; }
    public DateTime DataCadastro { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public Cliente? Cliente { get; set; }
}