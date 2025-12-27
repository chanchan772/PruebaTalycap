using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalycapGlobalNet.Core;

namespace TalycapGlobalNet.Infrastructure
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(TalycapGlobalNetDbContext context) : base(context)
        {
        }

        public async Task<Cliente> GetByIdentificacionAsync(string identificacion)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Cedula == identificacion);
        }
    }
}