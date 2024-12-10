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
        Task<cClienteMedicamento> getClienteMedicamento(string pIdClienteMedicamento);
        Task<bool> agregarClienteMedicamento(cClienteMedicamento pClienteMedicamento);
        Task<bool> actualizarClienteMedicamento(cClienteMedicamento pClienteMedicamento);
        Task<bool> eliminarClienteMedicamento(string pIdClienteMedicamento);
    }
}
