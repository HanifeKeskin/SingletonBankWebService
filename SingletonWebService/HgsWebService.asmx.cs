﻿using System;
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

        private HgsDataSet.HGSDataTable dtHgs;

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetAllHgs()
        {
            Context.Response.Write(getHgs());
        }

        private string getHgs()
        {
            dtHgs = taHgs.GetHgs();

            string myResponse = Newtonsoft.Json.JsonConvert.SerializeObject(dtHgs);
            return myResponse;
        }

        //public int hgsEkle(long hgsNo, string isim, string soyisim, string plaka, long tc)
        //{
        //    taHgs.HgsEkle(hgsNo, tc, isim, soyisim, plaka, 0 );
        //    string myResponse = Newtonsoft.Json.JsonTextWriter
        //}
    }
}
