using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmacia.Share.Model;

namespace Farmacia.BLL.Interface
{
    public interface IClienteMedicamento
    {

        Task<List<cClienteMedicamento>> getClienteMedicamentos();
        Task<bool> agregarClienteMedicamento(cClienteMedicamento pClienteMedicamento);
        Task<bool> actualizarClienteMedicamento(cClienteMedicamento pClienteMedicamento);
        Task<cClienteMedicamento> getClienteMedicamento(string idCliente, string idMedicamento);
        Task<bool> eliminarClienteMedicamento(cClienteMedicamento pClienteMedicamento);
    }
}
