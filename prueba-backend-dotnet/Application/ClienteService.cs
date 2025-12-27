using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalycapGlobalNet.Core;

namespace TalycapGlobalNet.Application
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return clientes.Select(cliente => new ClienteDto
            {
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                FechaNacimiento = cliente.FechaNacimiento,
                Cedula = cliente.Cedula,
                Domicilio = cliente.Domicilio,
                TelefonoCelular = cliente.TelefonoCelular,
                Email = cliente.Email
            });
        }

        public async Task<ClienteDto> GetClienteByIdentificacionAsync(string identificacion)
        {
            var cliente = await _clienteRepository.GetByIdentificacionAsync(identificacion);
            if (cliente == null)
            {
                return null;
            }

            return new ClienteDto
            {
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                FechaNacimiento = cliente.FechaNacimiento,
                Cedula = cliente.Cedula,
                Domicilio = cliente.Domicilio,
                TelefonoCelular = cliente.TelefonoCelular,
                Email = cliente.Email
            };
        }
    }
}