using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;
using System.Media;

namespace inglesnati
{
    public partial class Listening : Form
    {
        public Listening()
        {
            InitializeComponent();
            checaraudiosdisponiveis();
            atualizarlista();
        }

        //Algoritmo para checar audios disponiveis para download que o Usuario não tem.
        public void checaraudiosdisponiveis()
        {

            try {

            string query = "SELECT DISTINCT nome FROM audios WHERE nome NOT IN(SELECT DISTINCT nome FROM audiosbaixados"+confusers.usuario+");";
            conexao checaraudiosdisponiveisparadownload = new conexao();
            var audiosbaixar = checaraudiosdisponiveisparadownload.retornarDados(query);

            if (audiosbaixar.Rows.Count > 0)
            {
                for (int i = 0; i < audiosbaixar.Rows.Count; i++)
                {
                    ComboBoxAudiosPBaixar.Items.Add(audiosbaixar.Rows[i]["nome"].ToString());

                }

            }
            else
            {
                MessageBox.Show("Não há no momento audios disponíveis para baixar. ");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        //Pega o link de download do arquivo e colocar na var confusers.link

        public void linkdownload()
        {
            try{
            string query = "SELECT link FROM audios WHERE nome='" + ComboBoxAudiosPBaixar.Text + "' ";
            conexao linkdownload = new conexao();
            var linkaudiosbaixar = linkdownload.retornarDados(query);
            confusers.link = linkaudiosbaixar.Rows[0]["link"].ToString();
            //Funcao baixar novos audios
              //     baixarnovosaudios();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //INSERIR NA TABELA arquivosbaixadosusuario os arquivos que ele baixou
        public void atualizarlistadeaudios()
        {
            try
            {
                string query = "INSERT INTO audiosbaixados" + confusers.usuario + " (nome, caminho) SELECT nome, caminho FROM audios WHERE nome='" + ComboBoxAudiosPBaixar.Text + "'";
                conexao usuariobaixou = new conexao();
                usuariobaixou.executar(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

                       
        }
        
        //função do combo para atualizar alista de arquivos que o usuario baixou

        public void atualizarlista()
        {
            string query = "SELECT * FROM audiosbaixados"+confusers.usuario+"; ";
            conexao usuariobaixou = new conexao();
            var updateaudios = usuariobaixou.retornarDados(query);


            if (updateaudios.Rows.Count > 0)
            {
                for (int i = 0; i < updateaudios.Rows.Count; i++)
                {
                    comboescolheraudio.Items.Add(updateaudios.Rows[i]["nome"].ToString());
                }

            }
            else
            {
                MessageBox.Show("Você ainda não baixou nenhum audio.");
            }
           
        }


        //selecionando o caminho do audio - funcao play
        public void caminhodoaudio()
        {

            try
            {

                string query = "SELECT caminho FROM audiosbaixados" + confusers.usuario + "  WHERE nome='" + comboescolheraudio.Text + "'; ";
                conexao pathaudio = new conexao();
                var caminhodoaudiolista = pathaudio.retornarDados(query);
                var caminhomusica = AppDomain.CurrentDomain.BaseDirectory;
                axWindowsMediaPlayer1.URL = caminhomusica + caminhodoaudiolista.Rows[0]["caminho"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Listening_Load(object sender, EventArgs e)
        {

        }

        public void exibirtexto()
        {
            string query = "SELECT texto FROM audios  WHERE nome='" + comboescolheraudio.Text + "'; ";
            conexao exibitexto = new conexao();
            var mostrartexto = exibitexto.retornarDados(query);
            textooriginal.Text = mostrartexto.Rows[0]["texto"].ToString();
        }
     

        /////////////////////////////////////////////////////////////////////////////////////////////

        //Botão de download do novo audio

       private void BTdownloadAudio_Click(object sender, EventArgs e)
       {

           pegalinkdownload();
           pegacaminhoparasalvar();
           backgroundWorker1.RunWorkerAsync();

           //antigo mecanismo de download
          // linkdownload();
       }

       private void button2_Click(object sender, EventArgs e)
       {
           
       }


        //Botao PLAY para ouvir o audio
       private void BTplay_Click(object sender, EventArgs e)
       {
           caminhodoaudio();
       }





        ////################################################/////////Algoritmo de download com progress bar

       ////CARREGAR COMBO NA INICIALIZAÇÃO

       public void pegacaminhoparasalvar()
       {

           try
           {

               string query = "SELECT caminho FROM audios  WHERE nome='" + ComboBoxAudiosPBaixar.Text + "'; ";
               conexao pathaudioa = new conexao();
               //caminho que o audio ficará    audio\audio.mp3
               var caminhodoaudiolistaa = pathaudioa.retornarDados(query);
               var diraudio = AppDomain.CurrentDomain.BaseDirectory;
               string audiourl = confusers.link;
               if (caminhodoaudiolistaa.Rows.Count > 0)
               {
                   for (int j = 0; j < caminhodoaudiolistaa.Rows.Count; j++)
                   {
                       //caminho na tabela audios
                       confusers.sFilePathToWriteFileTo = diraudio + @caminhodoaudiolistaa.Rows[j]["caminho"].ToString();
                   }

               }
               else
               {
                   MessageBox.Show("Não há no momento audios disponíveis para baixar. ");
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }

       }







       public void pegalinkdownload()
       {

           string query = "SELECT link FROM audios WHERE nome='" + ComboBoxAudiosPBaixar.Text + "' ";
           conexao linkdownload = new conexao();
           var linkaudiosbaixar = linkdownload.retornarDados(query);
           confusers.link = linkaudiosbaixar.Rows[0]["link"].ToString();

       }










        /// <summary>
        /// INICIO  ALGORITMO  BARRA DE PROGRESSO
   
       private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
       {

           // pega o link para fazer o download

           string sUrlToReadFileFrom = confusers.link.ToString();

           // caminho para salvar o arquivo


           string sFilePathToWriteFileTo = confusers.sFilePathToWriteFileTo.ToString();



           //pega quantos bytes tem o arquivo

           Uri url = new Uri(sUrlToReadFileFrom);

           System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

           System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

           response.Close();

           // gets the size of the file in bytes

           Int64 iSize = response.ContentLength;



           // atualiza o progressbar

           Int64 iRunningByteTotal = 0;



           // use the webclient object to download the file

           using (System.Net.WebClient client = new System.Net.WebClient())
           {

               // open the file at the remote URL for reading

               using (System.IO.Stream streamRemote = client.OpenRead(new Uri(sUrlToReadFileFrom)))
               {

                   // using the FileStream object, we can write the downloaded bytes to the file system

                   using (Stream streamLocal = new FileStream(confusers.sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None))
                   {

                       // loop the stream and get the file into the byte buffer

                       int iByteSize = 0;

                       byte[] byteBuffer = new byte[iSize];

                       while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                       {

                           // write the bytes to the file system at the file path specified

                           streamLocal.Write(byteBuffer, 0, iByteSize);

                           iRunningByteTotal += iByteSize;



                           // calculate the progress out of a base "100"

                           double dIndex = (double)(iRunningByteTotal);

                           double dTotal = (double)byteBuffer.Length;

                           double dProgressPercentage = (dIndex / dTotal);

                           int iProgressPercentage = (int)(dProgressPercentage * 100);



                           // update the progress bar

                           backgroundWorker1.ReportProgress(iProgressPercentage);

                       }



                       // clean up the file stream

                       streamLocal.Close();

                   }



                   // close the connection to the remote server

                   streamRemote.Close();

               }

           }



       }

       private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
       {
           progressBar1.Value = e.ProgressPercentage;
       }

       private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
       {
           MessageBox.Show("O download do audio está completo");
           //FUNCAO ATUALIZA LISTA DE AUDIOS
           atualizarlistadeaudios();
           //Limpar a lista de audios do combobox comboescolheraudio
           comboescolheraudio.Items.Clear();
           //atualizar  lista de audios que o usuario tem
           atualizarlista();






       }

       private void BTcomparar_Click(object sender, EventArgs e)
       {
           exibirtexto();
       }

       private void BTenviartexto_Click(object sender, EventArgs e)
       {

       }
       }
}


    




