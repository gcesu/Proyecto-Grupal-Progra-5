using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Share.Model
{
    public class cClienteMedicamento
    {
        public string Identificacion { get; set; }
        public short IdMedicamento { get; set; }
        public string Dosis { get; set; }
        public cClienteMedicamento()
        {

            Identificacion = string.Empty;
            IdMedicamento = 0;
            Dosis = string.Empty;
        }

    }
}
