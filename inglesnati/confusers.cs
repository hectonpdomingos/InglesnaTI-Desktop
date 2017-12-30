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
  public static class confusers
    {
      //Dados FTP upload
      public static string update;
       
      public static string ftpusuario = "audios@hectonpdomingos.com.br";
      public static string ftpsenha = "7qrK4huwWgKX";
      public static string ftparquivo;
      public static string ftpcaminhoservidor = "ftp://hectonpdomingos.com.br/";

      //comandosql
      public static string TBsql;
      
    //VARIAVEIS DO PAINEL ADMINISTRATIVO

      public static string TBtitulogramatica;
      public static string TBtextogramatica;
      public static string TBtitulointerview;
      public static string TBtextointerview;
      public static string TBnomelistening;
      public static string TBtextolistening;
      public static string TBlinklistening;
      public static string TBcaminholistening;
      public static string TBtituloexpression;
      public static string TBtextoexpression;
      public static string TBtituloexercicioleitura;
      public static string TBtextoleitura;
      public static string TBvocabularioleitura;
      //Exercicios
      public static string CBtituloLeitura;
      public static string TextoLeitura;

      //Feedback
      public static string AceitoFeedBack;
      public static string log;
      public static string logdate;

      // DATA TIME
      public static string MySQLFormatDate;
      //Barra de progresso valor Calculado


      public static Double ProgressGramaticaCalculado;
      public static Double ProgressExpressoesCalculado;
      public static Double ProgressEntrevistasCalculado;
      public static Double ProgressListeningCalculado;
      public static Double ProgressSpeakCalculado;





      //Dados do servidor e banco de dados
      public static string mr;
      public static string conn = "Server=108.167.132.60;port=3306;Database=hecto042_bookit;Uid=hecto042;password=OwN6j5p70u;Convert Zero Datetime=True";
      // variaveis de usuario. Usuario logado, membro e o status do login
      public static string usuario;
      public static string senha;
      public static string membro; 
      public static bool logado;
      public static string tipodeconta;
      public static int id;
      // usado apenas no cadastro do usuario
      public static string nome;
      public static string email;

      //variaveis de leitura do artigo e pontos
      public static bool lido;
      public static int pontos;
      public static string artigoslidos;
      //public static string vocejaleu;


      public static string preconfiguracao;
      public static string link;
      public static string caminho;
      //variavel do form listening para download dos audios
      public static string sFilePathToWriteFileTo;


      //
      public static int min = 1;
      public static int max;


      //configuracoes personalisadas-conf usuario
      public static int permitirlerdepois;



      //variaveis para o passar para o paramentro
      public static string LoginDestinatario;
      public static string EnviarAssunto;
      public static string EnviarMensagem;
      public static string RemetenteRecebido;
      public static string AssuntoRecebido;
      public static string MensagemRecebida;
      


      //Info sobre o hostname

      public static string NetworkInternace;
      public static string DNS;
      public static string AnyCast;
      public static string MultiCast;
      public static string UniCast;




        //Console.WriteLine("Network Interface: {0}", netif.Name);
        //    IPInterfaceProperties properties = netif.GetIPProperties();
        //    foreach ( IPAddress dns in properties.DnsAddresses )
        //        Console.WriteLine("\tDNS: {0}", dns);
        //    foreach ( IPAddressInformation anycast in properties.AnycastAddresses )
        //        Console.WriteLine("\tAnyCast: {0}", anycast.Address);
        //    foreach ( IPAddressInformation multicast in properties.MulticastAddresses )
        //        Console.WriteLine("\tMultiCast: {0}", multicast.Address);
        //    foreach ( IPAddressInformation unicast in properties.UnicastAddresses )
        //        Console.WriteLine("\tUniCast: {0}", unicast.Address);



       
    }




}


       