using System.Net;

namespace Estore.Ce.Helpers
{
    public static class NetworkHelper
    {
        public static bool IsConnectedToServer()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationHelper.GetSoapEndpoint());
                request.Timeout = 2000; // ms
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
