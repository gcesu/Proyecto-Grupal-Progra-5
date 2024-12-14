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
using Farmacia.Share.Service;

namespace Farmacia.BLL.Service
{
    public class sClienteMedicamento:IClienteMedicamento
    {
        private string urlApi = "";

        public async Task<List<cClienteMedicamento>> getClienteMedicamentos()
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteMedicamento/getclientesmedicamentos";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.GetAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {

                    List<cClienteMedicamento> mLista = await respuesta.Content.ReadFromJsonAsync<List<cClienteMedicamento>>();
                    return mLista;

                }
                else
                {
                    return new List<cClienteMedicamento>();
                }
            }
            catch (Exception ex)
            {
                return new List<cClienteMedicamento>();
            }
        }

        //****************************************************************************

        public async Task<cClienteMedicamento> getClienteMedicamento(string idCliente, string idMedicamento)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/ClienteMedicamento/getclientemedicamento/{idCliente}/{idMedicamento}";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.GetAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {
                    cClienteMedicamento mClienteMedicamento = await respuesta.Content.ReadFromJsonAsync<cClienteMedicamento>();
                    return mClienteMedicamento;
                }
                else
                {
                    return new cClienteMedicamento();
                }
            }
            catch (Exception ex)
            {
                return new cClienteMedicamento();
            }
        }

        //****************************************************************************

        public async Task<bool> agregarClienteMedicamento(cClienteMedicamento pClienteMedicamento)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteMedicamento/insertclientemedicamento";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.PostAsJsonAsync(urlApi, pClienteMedicamento);
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

        public async Task<bool> actualizarClienteMedicamento(cClienteMedicamento pClienteMedicamento)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteMedicamento/updateclientemedicamento";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.PutAsJsonAsync(urlApi, pClienteMedicamento);
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

        public async Task<bool> eliminarClienteMedicamento(cClienteMedicamento pClienteMedicamento)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/ClienteMedicamento/deleteclientemedicamento/{pClienteMedicamento.Identificacion}/{pClienteMedicamento.IdMedicamento}";
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
