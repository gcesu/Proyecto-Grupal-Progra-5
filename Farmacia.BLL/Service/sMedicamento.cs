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
    public class sMedicamento : IMedicamento
    {

        private string urlApi = "";

        //****************************************************************************
        public async Task<List<cMedicamento>> getMedicamentos()
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + "api/Medicamento/getmedicamentos";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.GetAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {

                    List<cMedicamento> mLista = await respuesta.Content.ReadFromJsonAsync<List<cMedicamento>>();
                    return mLista;

                }
                else
                {
                    return new List<cMedicamento>();
                }
            }
            catch (Exception ex)
            {
                return new List<cMedicamento>();
            }


        }
        //****************************************************************************

        public async Task<cMedicamento> getMedicamento(string pIdMedicamento)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/Medicamento/getmedicamento/{pIdMedicamento}";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.GetAsync(urlApi);
                if (respuesta.IsSuccessStatusCode)
                {
                    cMedicamento mMedicamento = await respuesta.Content.ReadFromJsonAsync<cMedicamento>();
                    return mMedicamento;

                }
                else
                {
                    return new cMedicamento();
                }

            }
            catch (Exception ex)
            {
                 return new cMedicamento();
            }



        }
        //****************************************************************************
        public async Task<bool> agregarMedicamento(cMedicamento pMedicamento)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/Medicamento/insertmedicamento";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.PostAsJsonAsync(urlApi, pMedicamento);
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                return false;
            }
            
        }
        //****************************************************************************

        public async Task<bool> actualizarMedicamento(cMedicamento pMedicamento)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/Medicamento/updatemedicamento";
                var httpClient = new HttpClient();
                var respuesta = await httpClient.PutAsJsonAsync(urlApi, pMedicamento);
                if (respuesta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                return false;
            }
        }

        //****************************************************************************
        public async Task<bool> eliminarMedicamento(string pIdMedicamento)
        {
            try
            {
                cApiBase mapi = new cApiBase();
                urlApi = mapi.getWebApiUrl().ToString().Trim() + $"api/Medicamento/deletemedicamento/{pIdMedicamento}";
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
            catch (Exception e)
            {

                return false;
            }
        }

    }
}
