using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// Importaciones de los modelos y servicios
using Farmacia.Share.Model;     
using Farmacia.Share.Service;
using System.Data.SqlClient;

namespace Farmacia.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private string sqlConnectionString = "Data Source=68.168.208.58; " +
            "Initial Catalog=Progra5; " +
            "Persist Security Info=True; " +
            "TrustServerCertificate=True; " +
            "User ID=PrograV;" +
            "Password=Aqi90h7@9";  // Coneccion a la base de datos

        //********************************************************************
        [HttpGet]
        [Route("getclientes")]
        public async Task<ActionResult<List<cCliente>>> getClientes()
        {
            try
            {
                dsCliente mdsCliente = new dsCliente(sqlConnectionString);
                List<cCliente> mLista = await mdsCliente.getClientes();

                return Ok(mLista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //********************************************************************
        [HttpGet]
        [Route("getcliente/{identificacion}")]
        public async Task<ActionResult<cCliente>> getCliente(string identificacion)
        {
            try
            {
                dsCliente mdsCliente = new dsCliente(sqlConnectionString);
                cCliente mCliente = await mdsCliente.getCliente(identificacion);

                return Ok(mCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //********************************************************************
        [HttpPost]
        [Route("insertCliente")]
        public async Task<ActionResult<string>> InsertCliente(cCliente cliente)
        {
            try
            {
                dsCliente mdsCliente = new dsCliente(sqlConnectionString);
                bool resultado = await mdsCliente.insertCliente(cliente);
                if (resultado)
                {
                    return Ok("Cliente registrado correctamente");
                }
                else
                {
                    return BadRequest("Error al insertar el cliente");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //********************************************************************
        [HttpPut]
        [Route("updateCliente")]
        public async Task<ActionResult<string>> UpdateCliente(cCliente cliente)
        {
            try
            {
                dsCliente mdsCliente = new dsCliente(sqlConnectionString);
                bool resultado = await mdsCliente.updateCliente(cliente);
                if (resultado)
                {
                    return Ok("Cliente actualizado correctamente");
                }
                else
                {
                    return BadRequest("Error al actualizar el cliente");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //********************************************************************
        [HttpDelete]
        [Route("deleteCliente/{identificacion}")]
        public async Task<ActionResult<string>> DeleteCliente(string identificacion)
        {
            try
            {
                dsCliente mdsCliente = new dsCliente(sqlConnectionString);
                cCliente pCliente = new cCliente();
                pCliente.Identificacion = identificacion;
                bool resultado = await mdsCliente.deleteCliente(pCliente);
                if (resultado)
                {
                    return Ok("Cliente eliminado correctamente");
                }
                else
                {
                    return BadRequest("Error al eliminar el cliente");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
