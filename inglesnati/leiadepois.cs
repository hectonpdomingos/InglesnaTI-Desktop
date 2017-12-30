using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.IO;

namespace inglesnati
{
     public static class leiadepois
    {

        public static void sim()
        {
            string query = "UPDATE usuarios SET lerdepois='1' WHERE nome='"+confusers.usuario+"';";
            conexao leiasim =new conexao();
            leiasim.executar(query);
        }


            public static void nao()
        {
            string query = "UPDATE usuarios SET lerdepois='0' WHERE nome='" + confusers.usuario + "';";
            conexao leiasim =new conexao();
            leiasim.executar(query);
        }





            public static void checar()
            {
                if (confusers.permitirlerdepois == 1)
                {
                    string query = "TRUNCATE TABLE artigoslidos" + confusers.usuario + "";
                    conexao deletarregistrosdelidos = new conexao();
                    deletarregistrosdelidos.executar(query);
                    leiadepois.sim();
                }
                else
                {
                    leiadepois.nao();
                }

            }


    }
}
