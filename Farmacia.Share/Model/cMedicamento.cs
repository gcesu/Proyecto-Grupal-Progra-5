using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Share.Model
{
    public class cMedicamento
    {

        public short IdMedicamento { get; set; }
        public string Descripcion { get; set; }
        public string Presentacion { get; set; }
        public string Marca { get; set; }
        public string Estado { get; set; }

        public cMedicamento()
        {

            IdMedicamento = 0;
            Descripcion = string.Empty;
            Presentacion = string.Empty;
            Marca = string.Empty;
            Estado = string.Empty;

        }

    }
}
