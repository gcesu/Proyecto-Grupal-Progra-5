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
    public class sClienteMedicamento:IClienteMedicamento
    {
        private string urlApi = "";

        public async Task<List<cClienteMedicamento>> getClienteMedicamentos()
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteMedicamento/getclientemedicamentos";
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

        public async Task<cClienteMedicamento> getClienteMedicamento(string pIdClienteMedicamento)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/ClienteMedicamento/getclientemedicamento/{pIdClienteMedicamento}";
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
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteMedicamento/agregarclientemedicamento";
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
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/ClienteMedicamento/actualizarclientemedicamento";
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

        public async Task<bool> eliminarClienteMedicamento(string pIdClienteMedicamento)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/ClienteMedicamento/eliminarclientemedicamento/{pIdClienteMedicamento}";
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
