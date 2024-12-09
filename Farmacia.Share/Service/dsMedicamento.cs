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
    public class dsMedicamento
    {
        private string sqlConnectionString { get; set; }

        public dsMedicamento(string _sqlConnectionString)
        {
            this.sqlConnectionString = _sqlConnectionString;
        }

        protected SqlConnection dbcon()
        {
            return new SqlConnection(sqlConnectionString);
        }
        //********************************************************************

        public async Task<List<cMedicamento>> getMedicamentos()
        {
            try
            {
                var db = dbcon();
                var sql = @"SELECT IdMedicamento, Descripcion, Presentacion, Marca, Estado FROM Medicamento;";
                var resultado = await db.QueryAsync<cMedicamento>(sql.ToString());
                return resultado.ToList();

            }
            catch (Exception ex)
            {
                return new List<cMedicamento>();
            }
        }

        public async Task<cMedicamento> getMedicamento(int pIdMedicamento)
        {
            try
            {
                var db = dbcon();
                var sql = @"SELECT IdMedicamento, Descripcion, Presentacion, Marca, Estado FROM Medicamento WHERE IdMedicamento = @IdMedicamento;";
                var resultado = await db.QueryFirstOrDefaultAsync<cMedicamento>(sql.ToString(), new { pIdMedicamento });
                return resultado;
            }
            catch (Exception ex)
            {
                return new cMedicamento();
            }
        }

        public async Task<bool> insertMedicamento(cMedicamento pMedicamento)
        {
            try
            {
                var db = dbcon();
                var sql = @"INSERT INTO Medicamento (Descripcion, Presentacion, Marca, Estado) VALUES (@Descripcion, @Presentacion, @Marca, @Estado);";
                var resultado = await db.ExecuteAsync(sql.ToString(), new { pMedicamento.Descripcion, pMedicamento.Presentacion, pMedicamento.Marca, pMedicamento.Estado });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> updateMedicamento(cMedicamento pMedicamento)
        {
            try
            {
                var db = dbcon();
                var sql = @"UPDATE Medicamento SET Descripcion = @Descripcion, Presentacion = @Presentacion, Marca = @Marca, Estado = @Estado WHERE IdMedicamento = @IdMedicamento;";
                var resultado = await db.ExecuteAsync(sql.ToString(), new { pMedicamento.IdMedicamento, pMedicamento.Descripcion, pMedicamento.Presentacion, pMedicamento.Marca, pMedicamento.Estado });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> deleteMedicamento(cMedicamento pMedicamento)
        {
            try
            {
                var db = dbcon();
                var sql = @"DELETE FROM Medicamento WHERE IdMedicamento = @IdMedicamento;";
                var resultado = await db.ExecuteAsync(sql.ToString(), new { pMedicamento.IdMedicamento });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
