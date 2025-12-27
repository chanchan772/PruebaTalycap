using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalycapGlobalNet.Application
{
    /// <summary>
    /// Objeto de transferencia de datos para el cliente.
    /// </summary>
    public class ClienteDto
    {
        /// <summary>
        /// Nombres del cliente.
        /// </summary>
        public string Nombres { get; set; }
        /// <summary>
        /// Apellidos del cliente.
        /// </summary>
        public string Apellidos { get; set; }
        /// <summary>
        /// Fecha de nacimiento del cliente.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }
        /// <summary>
        /// Número de cédula del cliente.
        /// </summary>
        public string Cedula { get; set; }
        /// <summary>
        /// Domicilio del cliente.
        /// </summary>
        public string Domicilio { get; set; }
        /// <summary>
        /// Teléfono celular del cliente.
        /// </summary>
        public string TelefonoCelular { get; set; }
        /// <summary>
        /// Correo electrónico del cliente.
        /// </summary>
        public string Email { get; set; }
    }
}