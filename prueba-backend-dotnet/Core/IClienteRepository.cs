using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalycapGlobalNet.Core
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> GetByIdentificacionAsync(string identificacion);
    }
}