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

namespace inglesnati
{
    public partial class PainelAdministrativo : Form
    {
        public PainelAdministrativo()
        {
            InitializeComponent();
            ChecarUsuarioMembro();
        }


        //Controle de usuario
        public void ChecarUsuarioMembro()
        {
            if (confusers.membro == "Estudante")
            {
                tabsistema.IsAccessible = false;

            }
            if (confusers.membro == "Admin")
            {

                tabsistema.IsAccessible = true;
            }

        }




        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //TAB CONTEUDO GRAMATICA

        public void EnviartextoTabelaArtigo()
        {
            try
            {

                confusers.TBtitulogramatica = TBtitulogramatica.Text;
                confusers.TBtextogramatica = TBtextogramatica.Text;
                string query = "INSERT INTO artigos (`id`, `nome`, `conteudo`, `tipo`) VALUES (NULL,@TBtitulogramatica, @TBtextogramatica, 'gramaticageral');";
                conexao enviar = new conexao();
                enviar.executar(query);
                MessageBox.Show("Texto Enviado");
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERRO inserir artigo na tabela artigos.  " + e.Message);
            }
        }

        public void EnviarTextoGramaticaParaArtigosgramatica()
        {
            try
            {

                //confusers.TBtitulogramatica = TBtitulogramatica.Text;
                //confusers.TBtextogramatica = TBtextogramatica.Text;
                string query = "INSERT INTO artigosgramatica (`id`,`nome`, `conteudo`) VALUES('', @TBtitulogramatica, @TBtextogramatica);";
                conexao enviar = new conexao();
                enviar.executar(query);
                MessageBox.Show("Texto Enviado");
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERRO inserir artigo na tabela artigosgramatica.  " + e.Message);
            }

        }

        //TAB CONTEUDO INTERVIEW
        public void EnviarTextoInterview()
        {

            try
            {

                confusers.TBtitulointerview = TBtitulointerview.Text;
                confusers.TBtextointerview = TBtextointerview.Text;
                string query = "INSERT INTO artigosentrevistas (`id`,`nome`, `conteudo`) VALUES('', @TBtitulointerview, @TBtextointerview);";
                conexao enviar = new conexao();
                enviar.executar(query);
                MessageBox.Show("Texto Enviado");
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERRO inserir artigo na tabela artigosinterview.  " + e.Message);
            }



        }

        //TAB CONTEUDO EXPRESSÕES
        public void EnviarTextoExpression()
        {
            try
            {

                confusers.TBtituloexpression = TBtituloexpression.Text;
                confusers.TBtextoexpression = TBtextoexpression.Text;
                string query = "INSERT INTO artigosexpressoes (`id`,`nome`, `conteudo`) VALUES('', @TBtituloexpression, @TBtextoexpression);";
                conexao enviar = new conexao();
                enviar.executar(query);
                MessageBox.Show("Texto Enviado");
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERRO inserir artigo na tabela artigosexpression.  " + e.Message);
            }

        }







        // TAB ENVIAR EXERCICIO LISTENING

        public void ListeningEFTP()
        {

            try
            {
                string URL = confusers.ftpcaminhoservidor + TBnomelistening.Text + ".mp3";

                WebClient client = new WebClient();
                {
                    client.Credentials = new NetworkCredential(confusers.ftpusuario, confusers.ftpsenha);
                    client.UploadFile(URL, "STOR", confusers.ftparquivo);
                    MessageBox.Show("Arquivo enviado com Sucesso!");
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("ERRO AO ENVIAR O ARQUIVO DE AUDIO   " + ex.Message);
            }

        }


        public void EnviarTextoLinkAudios()
        {

            try
            {

                confusers.TBnomelistening = TBnomelistening.Text;
                confusers.TBtextolistening = TBtextolistening.Text;
                confusers.TBlinklistening = "http://hectonpdomingos.com.br/audios/" + TBnomelistening.Text + ".mp3";
                confusers.TBcaminholistening = "audio\\" + TBnomelistening.Text + ".mp3";

                string query = "INSERT INTO audios (`id`,`nome`, `texto`, `link`, `caminho`) VALUES('', @TBnomelistening, @TBtextolistening, @TBlinklistening, @TBcaminholistening);";
                conexao enviar = new conexao();
                enviar.executar(query);
                MessageBox.Show("Texto Enviado");
            }
            catch (MySqlException e)
            {
                MessageBox.Show("ERRO inserir artigo na tabela Audios.  " + e.Message);
            }




        }






        //BOTAO DE ENVIAR TEXTO NA TABELA ARTIGOS E ARTIGOSGRAMARICA
        private void BTenviartexto_Click(object sender, EventArgs e)
        {
            if (TBtitulogramatica.Text == "" || TBtextogramatica.Text == "")
            {
                MessageBox.Show("Exite campos em branco. Check o campo nome do texto e o conteúdo do texto");
            }
            else
            {

                EnviartextoTabelaArtigo();
                EnviarTextoGramaticaParaArtigosgramatica();
            }

        }

        //BOTAO DE ENVIAR TEXTO INTERVIEW

        private void BTpostarinterview_Click(object sender, EventArgs e)
        {
            if (TBtitulointerview.Text == "" || TBtextointerview.Text == "")
            {
                MessageBox.Show("Exite campos em branco. Check o campo nome do texto e o conteúdo do texto");
            }
            else
            {

                EnviarTextoInterview();
            }
        }

        //BOTAO DE ENVIAR TEXTO EXPRESSION
        private void BTenviarexpression_Click(object sender, EventArgs e)
        {
            if (TBtituloexpression.Text == "" || TBtextoexpression.Text == "")
            {
                MessageBox.Show("Exite campos em branco. Check o campo nome do texto e o conteúdo do texto");
            }
            else
            {
                EnviarTextoExpression();
            }
        }

        //BOTAO DE ENVIAR LISTENING
        private void BTenviarlistening_Click(object sender, EventArgs e)
        {
            if (TBnomelistening.Text == "" || TBtextolistening.Text == "" || TBArquivoEscolhido.Text == "")
            {
                if (TBArquivoEscolhido.Text == "")
                {
                    MessageBox.Show("Você ainda não escolheu o audio para enviar. Click no botão Enviar audio e escolha o audio desejado");
                }
                MessageBox.Show("Exite campos em branco. Check o campo nome do texto e o conteúdo do texto");
            }
            else
            {
                ListeningEFTP();
                EnviarTextoLinkAudios();
            }
        }


        //BOTAO CARREGAR TABELA USUARIOS
        private void BTcarregartabelausuarios_Click(object sender, EventArgs e)
        {
            string conexaodb = confusers.conn;
            MySqlConnection conDataBase = new MySqlConnection(conexaodb);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT nomecompleto AS Nome_Completo, email AS Email, nome As Login, senha AS Senha, tipodeconta AS Grupo,  pontos AS Pontuação, datacadastro AS Cadastro FROM usuarios ORDER BY datacadastro DESC;", conDataBase);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        public void ComandoSql()
        {

            string constring = confusers.conn;
            string query = "@TBsql";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(query, conDataBase);
            cmdDataBase.Parameters.AddWithValue("@TBsql", TBsql.Text);
            MySqlDataReader myReader;

            conDataBase.Open();
            myReader = cmdDataBase.ExecuteReader();
            while (myReader.Read())
            {

                TBresultadosql.Text += myReader.GetString("nome");



            }
            conDataBase.Close();


        }


        private void BTexecutarsql_Click(object sender, EventArgs e)
        {
            ComandoSql();
        }

        private void PainelAdministrativo_Load(object sender, EventArgs e)
        {

        }

        //BOTAO PARA ESCOLHER O AUDIO PARA ENVIAR PARA O FTP
        private void BTEnviarAudioParaFTP_Click(object sender, EventArgs e)
        {
            OpenFileDialog arquivo = new OpenFileDialog();
            arquivo.Filter = "Audio MP3 | *.mp3";
            if (arquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                confusers.ftparquivo = arquivo.FileName;
                TBArquivoEscolhido.Text = arquivo.FileName;
            }


        }

        //CONEXAO PARA ENVIAR O TEXTO PARA LEITURA
        public void Enviartextoleitura()
        {

            confusers.TBtituloexercicioleitura = TBtituloexercicioleitura.Text;
            confusers.TBtextoleitura = TBtextoleitura.Text;
            confusers.TBvocabularioleitura = TBvocabularioleitura.Text;

            try
            {
                string query = "INSERT INTO textos (`id`, `titulo`, `texto`, `vocabulario`) VALUES (NULL, @TBtituloexercicioleitura, @TBtextoleitura, @TBvocabularioleitura)";
                conexao con = new conexao();
                con.executar(query);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERRO " + ex.Message);
            }
            MessageBox.Show("Texto enviado com sucesso!");
        }

        //BOTAO DE ENVIAR TEXTO PARA LEITURA
        private void BTenviartextoleitura_Click(object sender, EventArgs e)
        {


            if (TBtituloexercicioleitura.Text == "" || TBtextoleitura.Text == "" || TBvocabularioleitura.Text == "")
            {

                MessageBox.Show("Exite campos em branco. Check TODOS os campos.");
            }
            else
            {
                Enviartextoleitura();
            }
        }
    }
}
