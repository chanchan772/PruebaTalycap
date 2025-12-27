using Microsoft.AspNetCore.Mvc;
using TalycapGlobalNet.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TalycapGlobalNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Obtiene una lista de todos los clientes.
        /// </summary>
        /// <returns>Una lista de clientes.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClienteDto>), 200)]
        public async Task<IActionResult> Get()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        /// <summary>
        /// Obtiene un cliente por su número de identificación (cédula).
        /// </summary>
        /// <param name="identificacion">El número de identificación del cliente.</param>
        /// <returns>El cliente solicitado.</returns>
        [HttpGet("{identificacion}")]
        [ProducesResponseType(typeof(ClienteDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(string identificacion)
        {
            var cliente = await _clienteService.GetClienteByIdentificacionAsync(identificacion);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
    }
}