using System;
using System.Configuration;
using System.Xml;
using System.Reflection;
using System.IO;

namespace Estore.Ce.Helpers
{
    public class ConfigurationHelper
    {
        public static string GetConnectionString(string name)
        {
            string applicationFolder = GetApplicationFolder();
            XmlDocument config = new XmlDocument();
            config.Load(applicationFolder + @"\AppSettings.xml");

            XmlNode node = config.SelectSingleNode("/Configuration/ConnectionStrings/Add[@Name='" + name + "']");
            if (node != null && node.Attributes["ConnectionString"] != null)
            {
                return node.Attributes["ConnectionString"].Value.Replace("applicationFolder",applicationFolder);                
            }

            throw new Exception("Connection string '" + name + "' not found.");
        }

        public static string GetSoapEndpoint()
        {
            string applicationFolder = GetApplicationFolder();
            XmlDocument config = new XmlDocument();
            config.Load(applicationFolder + @"\AppSettings.xml");

            XmlNode node = config.SelectSingleNode("/Configuration/Endpoints/Add[@Name='SoapEndpoint']");
            if (node != null && node.Attributes["Endpoint"] != null)
            {
                return node.Attributes["Endpoint"].Value;
            }

            throw new Exception("Soap endpoint not found.");
        }

        private static string GetApplicationFolder()
        {
            // Get the path to the currently executing assembly
            string assemblyPath = Assembly.GetExecutingAssembly().GetName().CodeBase;

            // Get the directory of the assembly
            string appFolder = Path.GetDirectoryName(assemblyPath);

            return appFolder;
        }
    }
}
