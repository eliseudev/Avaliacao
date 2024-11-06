using Application.Dtos;
using Application.Interfaces;
using Application.Validation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(ClienteDto cliente)
        {
            try
            {
                _clienteService.Create(cliente);
                return Ok("Cliente cadastrado com sucesso");
            }
            catch (ValidarDados ex)
            {
                return BadRequest(new { message =  ex.Message });
            }
        }

        [HttpGet("BuscarCliente/{id}")]
        public async Task<IActionResult> BuscarCliente([FromRoute] int id)
        {
            var customer = await _clienteService.ClienteById(id);

            if (customer is null) return NotFound("Cliente não encontrado");

            return Ok(customer);
        }

        [HttpGet("BuscarTodosClientes")]
        public async Task<IActionResult> BuscarTodosClientes()
        {
            var customer = await _clienteService.ListAll();

            if(!customer.Any()) return NotFound("Não existe clientes cadastrados");

            return Ok(customer);
        }

        [HttpPut("AtualizarCliente")]
        public async Task<IActionResult> AtualizarCliente([FromBody] ClienteDto cliente)
        {
            try
            {
                _clienteService.Update(cliente);
                return Ok();
            }
            catch (ValidarDados ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("DeletarUsuario/{id}")]
        public async Task<IActionResult> DeletarUsuario([FromRoute] int id)
        {
            _clienteService.Delete(id);
            return Ok();
        }
    }
}
