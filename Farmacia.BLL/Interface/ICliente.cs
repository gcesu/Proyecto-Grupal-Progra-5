using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmacia.Share.Model;
namespace Farmacia.BLL.Interface
{
    public interface ICliente
    {

        Task<List<cCliente>> getClientes();
        Task<cCliente> getCliente(string pIdCliente);
        Task<bool> agregarCliente(cCliente pCliente);
        Task<bool> actualizarCliente(cCliente pCliente);
        Task<bool> eliminarCliente(string pIdCliente);
        

    }
}
