using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmacia.Share.Model;

namespace Farmacia.BLL.Interface
{
    public interface IMedicamento
    {
        Task<List<cMedicamento>> getMedicamentos();
        Task<cMedicamento> getMedicamento(string pIdMedicamento);
        Task<bool> agregarMedicamento(cMedicamento pMedicamento);
        Task<bool> actualizarMedicamento(cMedicamento pMedicamento);
        Task<bool> eliminarMedicamento(string pIdMedicamento);




    }
}
