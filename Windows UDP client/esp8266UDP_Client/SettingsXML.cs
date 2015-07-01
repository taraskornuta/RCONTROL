using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCONTROL
{
    public class Settings
    {
        public static DataSet ds;
        public static string xmlPath;

        //User Settings variables
        public static bool Debug_Enable;
        public static string Debug_IP;
        public static string Debug_Port;
        public static bool Debug_Open_Console;
        public static bool Joy_Enable;

        public static void Load()
        {
            xmlPath = Application.StartupPath + "\\settings.xml";
        }

        public static void Read()
        {
            ds = new DataSet();
            ds.ReadXml(xmlPath);           
            DataRow dr = ds.Tables[0].Rows[0];

            Debug_Enable = (bool)dr["Debug_Enable"];
            Debug_IP = dr["Debug_IP"].ToString();
            Debug_Port = dr["Debug_Port"].ToString();
            Debug_Open_Console = (bool)dr["Debug_Open_Console"];
            Joy_Enable = (bool)dr["Joy_Enable"];
        }

        public static void Save()
        {
            ds = new DataSet();
            ds.ReadXml(xmlPath);

            ds.Tables[0].Rows[0]["Debug_Enable"] = Debug_Enable;
            ds.Tables[0].Rows[0]["Debug_IP"] = Debug_IP;
            ds.Tables[0].Rows[0]["Debug_Port"] = Debug_Port;
            ds.Tables[0].Rows[0]["Debug_Open_Console"] = Debug_Open_Console;
            ds.Tables[0].Rows[0]["Joy_Enable"] = Joy_Enable;

            ds.WriteXml(xmlPath, XmlWriteMode.WriteSchema);
        }
    }
}
