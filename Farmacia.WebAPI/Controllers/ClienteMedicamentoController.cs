using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Farmacia.Share.Model;
using Farmacia.Share.Service;

namespace Farmacia.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteMedicamentoController : ControllerBase
    {
        private string sqlConnectionString = "Data Source=68.168.208.58; " +
            "Initial Catalog=Progra5; " +
            "Persist Security Info=True; " +
            "TrustServerCertificate=True; " +
            "User ID=PrograV;" +
            "Password=Aqi90h7@9";  // Coneccion a la base de datos

        //********************************************************************
        [HttpGet]
        [Route("getclientesmedicamentos")]
        public async Task<ActionResult<List<cClienteMedicamento>>> getClientesMedicamentos()
        {
            try
            {
                dsClienteMedicamento mdsClienteMedicamento = new dsClienteMedicamento(sqlConnectionString);
                List<cClienteMedicamento> mLista = await mdsClienteMedicamento.getClienteMedicamentos();

                return Ok(mLista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //********************************************************************
        [HttpGet]
        [Route("getclientemedicamento/{idCliente}/{idMedicamento}")]
        public async Task<ActionResult<cClienteMedicamento>> getClienteMedicamento(string idCliente, int idMedicamento)
        {
            try
            {
                dsClienteMedicamento mdsClienteMedicamento = new dsClienteMedicamento(sqlConnectionString);
                cClienteMedicamento mClienteMedicamento = await mdsClienteMedicamento.getClienteMedicamento(idCliente, idMedicamento);
                if (mClienteMedicamento == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mClienteMedicamento);

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //********************************************************************
        [HttpPost]
        [Route("insertclientemedicamento")]
        public async Task<ActionResult<string>> InsertClienteMedicamento(cClienteMedicamento clienteMedicamento)
        {
            try
            {
                dsClienteMedicamento mdsClienteMedicamento = new dsClienteMedicamento(sqlConnectionString);
                bool mResultado = await mdsClienteMedicamento.insertClienteMedicamento(clienteMedicamento);
                if (mResultado)
                {
                    return Ok("Registro insertado");
                }
                else
                {
                    return BadRequest("Error al insertar el registro");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //********************************************************************
        [HttpPut]
        [Route("updateclientemedicamento")]
        public async Task<ActionResult<string>> UpdateClienteMedicamento(cClienteMedicamento clienteMedicamento)
        {
            try
            {
                dsClienteMedicamento mdsClienteMedicamento = new dsClienteMedicamento(sqlConnectionString);
                bool mResultado = await mdsClienteMedicamento.updateClienteMedicamento(clienteMedicamento);
                if (mResultado)
                {
                    return Ok("Registro actualizado");
                }
                else
                {
                    return BadRequest("Error al actualizar el registro");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //********************************************************************
        [HttpDelete]
        [Route("deleteclientemedicamento/{idCliente}/{idMedicamento}")]
        public async Task<ActionResult<string>> DeleteClienteMedicamento(string idCliente, int idMedicamento)
        {
            try
            {
                dsClienteMedicamento mdsClienteMedicamento = new dsClienteMedicamento(sqlConnectionString);
                cClienteMedicamento pClienteMedicamento = new cClienteMedicamento();
                pClienteMedicamento.Identificacion = idCliente;
                pClienteMedicamento.IdMedicamento = idMedicamento;
                bool mResultado = await mdsClienteMedicamento.deleteClienteMedicamento(pClienteMedicamento);
                if (mResultado)
                {
                    return Ok("Registro eliminado");
                }
                else
                {
                    return BadRequest("Error al eliminar el registro");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
