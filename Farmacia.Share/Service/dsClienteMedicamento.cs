using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Farmacia.Share.Model;

namespace Farmacia.Share.Service
{
    public class dsClienteMedicamento
    {
        private string sqlConnectionString { get; set; }

        public dsClienteMedicamento(string _sqlConnectionString)
        {
            this.sqlConnectionString = _sqlConnectionString;
        }

        protected SqlConnection dbcon()
        {
            return new SqlConnection(sqlConnectionString);
        }
        //********************************************************************

        public async Task<List<cClienteMedicamento>> getClienteMedicamentos()
        {
            try
            {
                var db = dbcon();
                var sql = @"SELECT Identificacion, IdMedicamento, Dosis FROM ClienteMedicamento;";
                var resultado = await db.QueryAsync<cClienteMedicamento>(sql.ToString());
                return resultado.ToList();

            }
            catch (Exception ex)
            {
                return new List<cClienteMedicamento>();
            }
        }

        public async Task<cClienteMedicamento> getClienteMedicamento(string pIdentificacion, short pIdMedicamento)
        {
            try
            {
                var db = dbcon();
                var sql = @"SELECT Identificacion, IdMedicamento, Dosis FROM ClienteMedicamento WHERE Identificacion = @Identificacion AND IdMedicamento = @IdMedicamento;";
                var resultado = await db.QueryFirstOrDefaultAsync<cClienteMedicamento>(sql.ToString(), new { pIdentificacion, pIdMedicamento });
                return resultado;
            }
            catch (Exception ex)
            {
                return new cClienteMedicamento();
            }
        }

        public async Task<bool> insertClienteMedicamento(cClienteMedicamento pClienteMedicamento)
        {
            try
            {
                var db = dbcon();
                var sql = @"INSERT INTO ClienteMedicamento (Identificacion, IdMedicamento, Dosis) VALUES (@Identificacion, @IdMedicamento, @Dosis);";
                var resultado = await db.ExecuteAsync(sql.ToString(), new { pClienteMedicamento.Identificacion, pClienteMedicamento.IdMedicamento, pClienteMedicamento.Dosis });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> updateClienteMedicamento(cClienteMedicamento pClienteMedicamento)
        {
            try
            {
                var db = dbcon();
                var sql = @"UPDATE ClienteMedicamento SET Dosis = @Dosis WHERE Identificacion = @Identificacion AND IdMedicamento = @IdMedicamento;";
                var resultado = await db.ExecuteAsync(sql.ToString(), new { pClienteMedicamento.Dosis, pClienteMedicamento.Identificacion, pClienteMedicamento.IdMedicamento });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> deleteClienteMedicamento(string pIdentificacion, short pIdMedicamento)
        {
            try
            {
                var db = dbcon();
                var sql = @"DELETE FROM ClienteMedicamento WHERE Identificacion = @Identificacion AND IdMedicamento = @IdMedicamento;";
                var resultado = await db.ExecuteAsync(sql.ToString(), new { pIdentificacion, pIdMedicamento });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
