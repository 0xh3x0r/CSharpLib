using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace _myCon
{


    public class myCon
    {

 
        // Define a conStr in your config file with <appSettings> tag named 'conStr'
        public static string conStr = ConfigurationManager.AppSettings["conStr"];


        SqlConnection conn;
        SqlCommand cmd;


     

        public myCon()
        {
            conn = new SqlConnection(conStr);
            conn.Open();

        }


        // Returns an instance of SqlCommand attached to this connection
        public SqlCommand CreateCmd()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                SqlCommand lcmd = new SqlCommand("",conn);
                this.cmd = lcmd;
                return lcmd;
            }
            else
                return null;

        }



        // Always close the DataReader returned from this function.
        public SqlDataReader GetData()
        {
           
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }


        public void AttachCmd(ref SqlCommand Cmd)
        {

            Cmd.Connection = conn;
            if(cmd != null)
            {
                cmd.Dispose();
            }

            this.cmd = Cmd;


        }




        public void RenewCmd(string cmdText)
        {
            this.cmd.CommandText = cmdText;
            
        }


        public void ForceClean()
        {
            conn.Close();
            conn.Dispose();
            if (cmd != null) cmd.Dispose();
        }



    }
}