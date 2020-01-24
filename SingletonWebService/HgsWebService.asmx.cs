using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

namespace SingletonWebService
{
    /// <summary>
    /// Summary description for HgsWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HgsWebService : System.Web.Services.WebService
    {
        private HgsDataSetTableAdapters.HGSTableAdapter taHgs = new HgsDataSetTableAdapters.HGSTableAdapter();


        [WebMethod]
        public bool hgsEkle(long hgsNo, long tc, string isim, string soyisim, string plaka)
        {
            taHgs.HgsEkle(hgsNo, tc, isim, soyisim, plaka, 0);
            return true;
        }


         [WebMethod]
         [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
         public string hgsSorgula(int HgsID)
         {
             //taHgs.HgsSorgu(HgsID);
             string myResponse = Newtonsoft.Json.JsonConvert.SerializeObject(taHgs.HgsSorgu(HgsID));
             return myResponse;
         }

      
        [WebMethod]
        public string hgsSatis(decimal hgsBakiye, int HgsID, decimal tutar)
        {
           
            decimal Bakiye = (hgsBakiye +tutar);
            string myResponse = Newtonsoft.Json.JsonConvert.SerializeObject(taHgs.HgsSatis(Bakiye,HgsID));
            return myResponse;
        }
    }
}
