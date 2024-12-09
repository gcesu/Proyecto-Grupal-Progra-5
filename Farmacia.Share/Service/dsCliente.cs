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
    public class dsCliente
    {
        private string sqlConnectionString { get; set; }

        public dsCliente(string _sqlConnectionString)
        {
            this.sqlConnectionString = _sqlConnectionString;
        }

        protected SqlConnection dbcon()
        {
            return new SqlConnection(sqlConnectionString);
        }
        //********************************************************************

        public async Task<List<cCliente>> getClientes()  // Funcion Asincrona
        {
            try
            {
                var db = dbcon();
                var sql = @"SELECT Identificacion, Nombre, FechaNacimiento, Telefono, Email, Estado FROM ClienteFarmacia ORDER BY Nombre;";
                var resultado = await db.QueryAsync<cCliente>(sql.ToString());  // Funcion Asincrona
                return resultado.ToList();
            }
            catch (Exception ex)
            {
                return new List<cCliente>();
            }
        }


        public async Task<cCliente> getCliente(string Identificacion)
        {
            try
            {
                var db = dbcon();
                var sql = @"SELECT Identificacion, Nombre, FechaNacimiento, Telefono, Email, Estado FROM ClienteFarmacia WHERE Identificacion = @Identificacion";
                var resultado = await db.QueryAsync<cCliente>(sql.ToString(), new { Identificacion = Identificacion });
                return resultado.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return new cCliente();
            }
        }

        public async Task<bool> insertCliente(cCliente pCliente)  // Funcion Asincrona
        {
            try
            {
                var db = dbcon();
                var sql = @"INSERT INTO ClienteFarmacia (Identificacion, Nombre, FechaNacimiento, Telefono, Email, Estado) VALUES (@Identificacion, @Nombre, @FechaNacimiento, @Telefono, @Email, @Estado);";
                var resultado = await db.ExecuteAsync(sql.ToString(), new { pCliente.Identificacion, pCliente.Nombre, pCliente.FechaNacimiento, pCliente.Telefono, pCliente.Email, pCliente.Estado });     // Parametros
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> updateCliente(cCliente pCliente)  // Funcion Asincrona
        {
            try
            {
                var db = dbcon();
                var sql = @"UPDATE ClienteFarmacia SET Nombre = @Nombre, FechaNacimiento = @FechaNacimiento, Telefono = @Telefono, Email = @Email, Estado = @Estado WHERE Identificacion = @Identificacion;";
                var resultado = await db.ExecuteAsync(sql.ToString(), new { pCliente.Identificacion, pCliente.Nombre, pCliente.FechaNacimiento, pCliente.Telefono, pCliente.Email, pCliente.Estado });     // Parametros
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> deleteCliente(cCliente pCliente)  // Funcion Asincrona
        {
            try
            {
                var db = dbcon();
                var sql = @"DELETE FROM ClienteFarmacia WHERE Identificacion = @Identificacion;";
                var resultado = await db.ExecuteAsync(sql.ToString(), new { pCliente.Identificacion });     // Parametros
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
