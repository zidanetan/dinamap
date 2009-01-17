using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Xml;

namespace DinamapN
{
    class Tool
    {
        //Las Funciones de la DLL DinaWin se declara en este punto.
        [DllImport("dinawin.dll")]
        internal static extern bool checkReadiness();

        [DllImport("dinawin.dll")]
        internal static extern string getState();

        [DllImport("dinawin.dll")]
        internal static extern int getBufferLength();

        [DllImport("dinawin.dll")]
        internal static extern bool resetMonitor();

        //Public Variables to the Class
        public static string szTitulo_APP = "(C)Dinamap - Monitoring Program";

        //Member of the Class
        public static string GetConfigurationRegistry(string key)
        {
            string strValue = "";
            try
            {
                strValue = Application.UserAppDataRegistry.GetValue(key).ToString();
            }
            catch
            {
                ;
            }
            return strValue;
        }

        public static bool SetConfigurationRegistry(string key, string strValue)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue(key, strValue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Dina_CheckReadiness()
        {
            bool bRet;

            bRet = checkReadiness();
 
            return bRet;
        }

        public static XmlDocument Dina_GetState()
        {
            XmlDocument xmlData = new XmlDocument();
            xmlData.Load("C:\\dinamap.xml");
            return xmlData;

            //szState = getState();

        }

        public static int Dina_GetBufferLength()
        {
            int nLon;

            nLon = getBufferLength();

            return nLon;
        }

        public static bool Dina_ResetMonitor()
        {
            bool bRet;

            bRet = resetMonitor();

            return bRet;
        }


    } //End of Class
}  //End of Namespace
