using Farmacia.BLL.Interface;
using Farmacia.BLL.Model;
using Farmacia.Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;

namespace Farmacia.BLL.Service
{
    public class sCliente : ICliente
    {
        private string urlApi = "";


        public async Task<List<cCliente>> getClientes()
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/Cliente/getclientes";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.GetAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {

                    List<cCliente> mLista = await respuesta.Content.ReadFromJsonAsync<List<cCliente>>();
                    return mLista;

                }
                else
                {
                    return new List<cCliente>();
                }
            }
            catch (Exception ex)
            {
                return new List<cCliente>();
            }




        }


        //****************************************************************************
        public async Task<cCliente> getCliente(string pIdCliente)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/Cliente/getcliente/{pIdCliente}";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.GetAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {
                    cCliente mCliente = await respuesta.Content.ReadFromJsonAsync<cCliente>();
                    return mCliente;
                }
                else
                {
                    return new cCliente();
                }
            }
            catch (Exception ex)
            {
                return new cCliente();
            }
        }
        //****************************************************************************

        public async Task<bool> agregarCliente(cCliente pCliente)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/Cliente/agregarcliente";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.PostAsJsonAsync(urlApi, pCliente);
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //****************************************************************************
        public async Task<bool> actualizarCliente(cCliente pCliente)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/Cliente/actualizarcliente";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.PutAsJsonAsync(urlApi, pCliente);
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //****************************************************************************

        public async Task<bool> eliminarCliente(string pIdCliente)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/Cliente/eliminarcliente/{pIdCliente}";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.DeleteAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
