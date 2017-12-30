using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Types;
using System.Data;

using System.IO;


namespace inglesnati
{
  public  class ConexaoParametrada
    {

      string constring = "Server=108.167.132.60;port=3306;Database=hecto042_bookit;Uid=hecto042;password=OwN6j5p70u;Allow User Variables=True;";
        public void executar(string sql)
        {
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand command = new MySqlCommand(sql, conDataBase);
            
            command.Parameters.AddWithValue("@LoginDestinatario", confusers.LoginDestinatario);
            command.Parameters.AddWithValue("@EnviarAssunto", confusers.EnviarAssunto);
            command.Parameters.AddWithValue("@EnviarMensagem", confusers.EnviarMensagem);
            
            
            //abrir conexao
            conDataBase.Open();
            
            command.ExecuteNonQuery();
            conDataBase.Close();
        }


        public DataTable retornarDados(string sql)
        {
            
                MySqlDataAdapter ad = new MySqlDataAdapter(sql, constring);
                DataTable ds = new DataTable();
                
                
                ad.Fill(ds);
                ad.Dispose();
                return ds;
           
        }

    }
}
