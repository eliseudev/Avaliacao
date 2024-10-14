using Customer.Banco;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer.Route;

[ApiController]
[Route("[controller]/[action]")]
public class ClienteController : Controller
{
    private readonly MeuContexto<Cliente> _context;

    public ClienteController()
    {
        var option = new DbContextOptions<MeuContexto<Cliente>>();
        _context = new MeuContexto<Cliente>(option);
    }
    
    [HttpPost]
    public IActionResult page(int page, int size = 200)
    {
        var cliente = _context.Listar(page, size);
        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult Obter(int id)
    {
        var cliente = _context.Find(id)!;
        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult Adicionar(Cliente cliente)
    {
        foreach (var end in cliente.Enderecos)
        {
            end.Cliente = cliente;
        }

        _context.Adicionar(cliente);
        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult Atualizar(Cliente cliente)
    {
        // foreach (var end in cliente.Enderecos)
        // {
        //     end.Cliente = cliente;
        // }
        _context.Atualizar(cliente);
        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult Deletar(int id)
    {
        var cliente = _context.Find(id)!;
        _context.Set<Cliente>().Remove(cliente);
        return Ok(cliente);
    }
}