using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Resources;

namespace inglesnati
{
    public partial class Atualizar : Form
    {
        public Atualizar()
        {
            InitializeComponent();
            checarautalizacoes();
        }


         

        ////CARREGAR COMBO NA INICIALIZAÇÃO
        public void checarautalizacoes()
        {

            string query = "SELECT informacoes from atualizacao";
            conexao checarupdates = new conexao();
            var baixar = checarupdates.retornarDados(query);

            if (baixar.Rows.Count > 0)
            {
                for (int i = 0; i < baixar.Rows.Count; i++)
                {
                    TBcorrecoesAtualizacao.Text = baixar.Rows[i]["informacoes"].ToString();
                                       

                }

            }
            else
            {
                MessageBox.Show("Não há no momento atualizações disponíveis para baixar. ");
            }


        }


        public void pegalinkdownload()
        {

            string query = "SELECT arquivo FROM atualizacao;";
            conexao linkdownload = new conexao();
            var linkaudiosbaixar = linkdownload.retornarDados(query);
            confusers.update = linkaudiosbaixar.Rows[0]["arquivo"].ToString();

        }
        public void pegacaminhoparasalvar()
        {
            string query = "SELECT caminho FROM atualizacao; ";
            conexao pathaudioa = new conexao();
            //caminho que o audio ficará    audio\audio.mp3
            var caminhoupdate = pathaudioa.retornarDados(query);
            var dirupdate = AppDomain.CurrentDomain.BaseDirectory;
            string audiourl = confusers.update;
            if (caminhoupdate.Rows.Count > 0)
            {
                for (int j = 0; j < caminhoupdate.Rows.Count; j++)
                {
                    //caminho na tabela audios
                    confusers.sFilePathToWriteFileTo = dirupdate + @caminhoupdate.Rows[j]["caminho"].ToString();
                }

            }
            else
            {
                MessageBox.Show("Não há no momento audios disponíveis para baixar. ");
            }


        }
       


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // the URL to download the file from

            string sUrlToReadFileFrom = confusers.update.ToString();

            // the path to write the file to


            string sFilePathToWriteFileTo = confusers.sFilePathToWriteFileTo.ToString();



            // first, we need to get the exact size (in bytes) of the file we are downloading

            Uri url = new Uri(sUrlToReadFileFrom);

            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

            response.Close();

            // gets the size of the file in bytes

            Int64 iSize = response.ContentLength;



            // keeps track of the total bytes downloaded so we can update the progress bar

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

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("File download complete");
            ExecutarArquivo();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }


        //EXECUTANDO A APLICAÇÃO
        private void ExecutarArquivo()
        {


            System.Diagnostics.Process.Start(confusers.sFilePathToWriteFileTo);


        }
        private void BTAtualizarPrograma_Click(object sender, EventArgs e)
        {
            pegalinkdownload();
            pegacaminhoparasalvar();
            backgroundWorker1.RunWorkerAsync();
           
        }
    }
}
