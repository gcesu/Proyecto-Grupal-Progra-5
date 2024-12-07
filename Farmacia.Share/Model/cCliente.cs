using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Share.Model
{
    public class cCliente
    {

        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }

        public cCliente()
        {

            Identificacion = string.Empty;
            Nombre = string.Empty;
            FechaNacimiento = DateTime.MinValue;
            Telefono = string.Empty;
            Email = string.Empty;
            Estado = string.Empty;

        }

    }
}
