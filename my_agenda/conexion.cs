using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace my_agenda
{
    class conexion
    {
        public static MySqlConnection conectar()
        {
            string server = "127.0.0.1";
            string database = "agenda_db";
            string user = "root";
            string pass = "";
            MySqlConnection cn = new MySqlConnection("Server=" + server + "; Database=" + database + "; uid=" + user + ";Pwd=" + pass + "");
            return cn;
        }


    }
}
