using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalycapGlobalNet.Application
{
    public interface IClienteService
    {
        Task<ClienteDto> GetClienteByIdentificacionAsync(string identificacion);
        Task<IEnumerable<ClienteDto>> GetAllAsync();
    }
}