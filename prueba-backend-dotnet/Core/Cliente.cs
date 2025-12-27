using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalycapGlobalNet.Core
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Cedula { get; set; }
        public string Domicilio { get; set; }
        public string TelefonoCelular { get; set; }
        public string Email { get; set; }
    }
}