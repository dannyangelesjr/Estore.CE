using System.Net;
using System;

namespace Estore.Ce.Helpers
{
    public static class NetworkHelper
    {
        public static bool IsConnectedToServer()
        {
            try
            {
                string soapEndpoint = ConfigurationHelper.GetSoapEndpoint();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(soapEndpoint);
                request.Timeout = 30000; // ms
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //return false;
            }
        }
    }
}
