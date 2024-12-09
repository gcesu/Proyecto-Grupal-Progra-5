using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Farmacia.Share.Model;
using Farmacia.Share.Service;

namespace Farmacia.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private string sqlConnectionString = "Data Source=68.168.208.58; " +
            "Initial Catalog=Progra5; " +
            "Persist Security Info=True; " +
            "TrustServerCertificate=True; " +
            "User ID=PrograV;" +
            "Password=Aqi90h7@9";  // Coneccion a la base de datos

        //********************************************************************
        [HttpGet]
        [Route("getmedicamentos")]
        public async Task<ActionResult<List<cMedicamento>>> getMedicamentos()
        {
            try
            {
                dsMedicamento mdsMedicamento = new dsMedicamento(sqlConnectionString);
                List<cMedicamento> mLista = await mdsMedicamento.getMedicamentos();

                return Ok(mLista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //********************************************************************
        [HttpGet]
        [Route("getmedicamento/{idMedicamento}")]
        public async Task<ActionResult<cMedicamento>> getMedicamento(string idMedicamento)
        {
            try
            {
                dsMedicamento mdsMedicamento = new dsMedicamento(sqlConnectionString);
                cMedicamento mMedicamento = await mdsMedicamento.getMedicamento(Convert.ToInt32(idMedicamento));
                if (mMedicamento == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(mMedicamento);

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //********************************************************************
        [HttpPost]
        [Route("insertmedicamento")]
        public async Task<ActionResult<string>> InsertMedicamento(cMedicamento medicamento)
        {
            try
            {
                dsMedicamento mdsMedicamento = new dsMedicamento(sqlConnectionString);
                bool resultado = await mdsMedicamento.insertMedicamento(medicamento);
                if (resultado)
                {
                    return Ok("Medicamento insertado correctamente");
                }
                else
                {
                    return BadRequest("Error al insertar el medicamento");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //********************************************************************
        [HttpPut]
        [Route("updatemedicamento")]
        public async Task<ActionResult<string>> UpdateMedicamento(cMedicamento medicamento)
        {
            try
            {
                dsMedicamento mdsMedicamento = new dsMedicamento(sqlConnectionString);
                bool resultado = await mdsMedicamento.updateMedicamento(medicamento);
                if (resultado)
                {
                    return Ok("Medicamento actualizado correctamente");
                }
                else
                {
                    return BadRequest("Error al actualizar el medicamento");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //********************************************************************
        [HttpDelete]
        [Route("deletemedicamento/{idMedicamento}")]
        public async Task<ActionResult<string>> DeleteMedicamento(short idMedicamento)
        {
            try
            {
                dsMedicamento mdsMedicamento = new dsMedicamento(sqlConnectionString);
                cMedicamento pMedicamento = new cMedicamento();
                pMedicamento.IdMedicamento = idMedicamento;
                bool resultado = await mdsMedicamento.deleteMedicamento(pMedicamento);
                if (resultado)
                {
                    return Ok("Medicamento eliminado correctamente");
                }
                else
                {
                    return BadRequest("Error al eliminar el medicamento");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
