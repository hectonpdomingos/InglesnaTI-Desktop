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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.IO;
namespace inglesnati
{
    public  static class Progress
    {

        public static  void ProgressoGramatica()
        {

            try
            {
                //ARTIGOS QUE O USUARIO MARCOU COMO LIDO

                string querygramatica = "SELECT COUNT(*) FROM progresso" + confusers.usuario + " WHERE tipo='gramaticageral';";
                conexao checarqtgrammar = new conexao();
                var dadosuser = checarqtgrammar.retornarDados(querygramatica);

                int real = Convert.ToInt32(dadosuser.Rows[0][0]);

                //HA UM BUG QUE SE O VALOR DO DOUBLE FOR IQUAL A 0  ELE BLOQUEIA A TELA DO LOGIN
                //13-06-15 ATE O MOMENTO NAO CONSEGUI SABER O PQ DO BLOQUEIO MAS UMA SOLUÇÃO TEMP FOI
                //BLOQUEAR ESSA PORRA ANTES DE CHEGAR NA VAR TIPO DOUBLE. HATESGONNAHATER
                if (real == 0)
                {
                    confusers.ProgressGramaticaCalculado = 0.1;

                }
                else
                {

                    //dados totais Artigos totais filtrados
                    string querygramatica2 = "SELECT COUNT(*) FROM artigos WHERE tipo='gramaticageral';";
                    conexao checarqtgrammartotal = new conexao();
                    var dadostotal = checarqtgrammartotal.retornarDados(querygramatica2);

                    int real2 = Convert.ToInt32(dadostotal.Rows[0][0]);


                    //EXEMPLO o usuario leu 2 artigos no total de 4 = 
                    double x = real2 / real;

                    confusers.ProgressGramaticaCalculado = 100 / x;

                }



            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void ProgressoExpressoes()
        {
            try
                {
                    //ARTIGOS QUE O USUARIO MARCOU COMO LIDO

                string queryexpressoes = "SELECT COUNT(*) FROM progresso" + confusers.usuario + " WHERE tipo='expressoesgeral';";
                conexao checarqtexpressoes = new conexao();
                var dadosexpressoes = checarqtexpressoes.retornarDados(queryexpressoes);
                int realexpressoes = Convert.ToInt32(dadosexpressoes.Rows[0][0]);
                if (realexpressoes == 0)
                {
                    confusers.ProgressExpressoesCalculado = 0.1;
                }
                else
                {

                    //dados totais Artigos totais filtrados
                    string queryexpressoes2 = "SELECT COUNT(*) FROM artigos WHERE tipo='expressoesgerais';";
                    conexao checarqtexpressoestotal = new conexao();
                    var dadostotalexpressoes = checarqtexpressoestotal.retornarDados(queryexpressoes2);

                    int totalexpressoes = Convert.ToInt32(dadostotalexpressoes.Rows[0][0]);


                    //EXEMPLO o usuario leu 2 artigos no total de 4 = 
                    double divisaoexpressoes = totalexpressoes / realexpressoes;

                    confusers.ProgressExpressoesCalculado = 100 / divisaoexpressoes;
                }    

             }
            
             
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

       }

        public static void ProgressoEntrevistas()
        {
            try
            {
                //ARTIGOS QUE O USUARIO MARCOU COMO LIDO

                string queryentrevistas = "SELECT COUNT(*) FROM progresso" + confusers.usuario + " WHERE tipo='entrevistageral';";
                conexao checarqtentrevistas = new conexao();
                var dadosentrevistas = checarqtentrevistas.retornarDados(queryentrevistas);
                int realentrevistas = Convert.ToInt32(dadosentrevistas.Rows[0][0]);
                if (realentrevistas == 0)
                {
                    confusers.ProgressEntrevistasCalculado = 0.1;
                }

                else
                {
                    //dados totais Artigos totais filtrados
                    string queryentrevista2 = "SELECT COUNT(*) FROM artigos WHERE tipo='entrevistageral';";
                    conexao checarqtentrevistatotal = new conexao();
                    var dadostotalentrevistas = checarqtentrevistatotal.retornarDados(queryentrevista2);

                    int totalentrevistas = Convert.ToInt32(dadostotalentrevistas.Rows[0][0]);


                    //EXEMPLO o usuario leu 2 artigos no total de 4 = 
                    double divisaoentrevista = totalentrevistas / realentrevistas;

                   
                   
                        confusers.ProgressEntrevistasCalculado = 100 / divisaoentrevista;
                    }

            }


            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }



       }
        //progresso listening  ProgressoListening
        public static void ProgressoListening()
        {
            try
            {
                //ARTIGOS QUE O USUARIO MARCOU COMO LIDO

                string querylistening = "SELECT COUNT(*) FROM audiosbaixados" + confusers.usuario + ";";
                conexao checarqtlistening = new conexao();
                var dadoslistening = checarqtlistening.retornarDados(querylistening);
                int reallistening = Convert.ToInt32(dadoslistening.Rows[0][0]);
                if (reallistening == 0)
                {

                    confusers.ProgressListeningCalculado = 0.1;
                }

                else
                {
                    //dados totais Artigos totais filtrados
                    string querylistening2 = "SELECT COUNT(*) FROM audios;";
                    conexao checarqtlisteningtotal = new conexao();
                    var dadostotallistening = checarqtlisteningtotal.retornarDados(querylistening2);

                    int totallistening = Convert.ToInt32(dadostotallistening.Rows[0][0]);

                    //EXEMPLO o usuario leu 2 artigos no total de 4 = 
                    double divisaolistening = totallistening / reallistening;

                    confusers.ProgressListeningCalculado = 100 / divisaolistening;
                }

            }


            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }



        }



    }
}
