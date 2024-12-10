using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.BLL.Model
{
    public class cApiBase
    {

        //private string WebApiUrl = "https://gymapi.kasecr.com/";
        private string WebApiUrl = "https://localhost:7234/";

        public string getWebApiUrl()
        {
            return WebApiUrl;
        }





    }
}
