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

namespace inglesnati
{
    /// <summary>
    /// Interaction logic for CadastroUsers.xaml
    /// </summary>
    public partial class CadastroUsers : Window
    {
        public CadastroUsers()
        {
            InitializeComponent();

            ComboBocOferta();
            ComboBoxTipoDeConta();

        }


        //BOTAO DE CADASTRO 
        private void cadastrarusuario(object sender, RoutedEventArgs e)
        {
            //confusers.email = email.Text;

            CadastroUnico();


        }

        //CHECAR SE HÁ O EMAIL CADASTRADO
        public void CadastroUnico()
        {



            string query = "SELECT email FROM usuarios where email='"+ email.Text +"';";
            conexao MDados = new conexao();
            var view = MDados.retornarDados(query);
            confusers.email = view.Rows[0]["email"].ToString();
            if (email.Text == confusers.email)
            {
                MessageBox.Show("Consta em nosso banco de dados que existe um usuário cadastrado com este E-Mail. Por favor, check novamente o E-mail digitado.");

            }
            else
            {
                conta();
                criartabelaartigoslidos();
                criartabelaaudiosusuario();
                CriandoCaixadeEmailEnviado();
                CriandoCaixaEmailRecebido();
                CriarTabelaProgresso();

            }
        }




        //COMBO OFERTAS

        public void ComboBocOferta()
        {
            CBReceberofertas.Items.Add("SIM");
            CBReceberofertas.Items.Add("NÃO");
        }
        
        //COMBO TIPO DE CONTA

        public void ComboBoxTipoDeConta()
        {
            CBtipodeconta.Items.Add("Instrutor");
            CBtipodeconta.Items.Add("Estudante");
        }


        //Criando usuario
        public void conta()
        {
            confusers.nome = nomecompleto.Text;
            confusers.email = email.Text;
            confusers.usuario = login.Text;
            confusers.senha = senha.Password;

            //command.Parameters.AddWithValue("@nomecompleto", confusers.nome);
            //command.Parameters.AddWithValue("@email", confusers.email);
            //command.Parameters.AddWithValue("@login", confusers.usuario);
            //command.Parameters.AddWithValue("@senha", confusers.senha);



            try
            {
                DateTime dateValue = DateTime.Now;
                confusers.MySQLFormatDate = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO usuarios (nomecompleto, email, nome, senha, tipodeconta, receberoferta, datacadastro) VALUES (@nomecompleto, @email, @login, @senha, '" + CBtipodeconta.Text + "', '" + CBReceberofertas.Text + "', @datacadastro );";
                conexao cadastrarusuario = new conexao();
                cadastrarusuario.executar(query);
                MessageBox.Show("Usuario Cadastrado com Sucesso!");

                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "ERRO na criação da conta do usuário");
            }



        }


        //Criando tabela de artigos lidos 
        public void criartabelaartigoslidos()
        {
            try
            {
                string query = "CREATE TABLE IF NOT EXISTS `artigoslidos" + login.Text + "` (`id` INT(11) NOT NULL AUTO_INCREMENT,`nome` VARCHAR(250) NULL,	PRIMARY KEY (`id`),	UNIQUE INDEX `id` (`id`))COLLATE='utf8_general_ci'ENGINE=InnoDB;";
                conexao criartabelaartigoslidosusuario = new conexao();
                criartabelaartigoslidosusuario.executar(query);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Erro na criação da tabela de artigos ligos");
            }



        }



        //criando tabela de audios baixados
        public void criartabelaaudiosusuario()
        {
            try
            {
                string query = "CREATE TABLE `hecto042_bookit`.`audiosbaixados" + login.Text + "` ( `id` INT(11) NOT NULL AUTO_INCREMENT , `nome` VARCHAR(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , `caminho` VARCHAR(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`) ) ENGINE = InnoDB CHARACTER SET utf8 COLLATE utf8_general_ci;";

                //string query = "CREATE TABLE `hecto042_bookit`.`audiosbaixados" + confusers.usuario + "` ( `id` INT NOT NULL AUTO_INCREMENT , `nome` VARCHAR(250), `caminho` VARCHAR(250) NOT NULL, CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`) ) ENGINE = InnoDB CHARACTER SET utf8 COLLATE utf8_general_ci;";
                conexao criandotabelaaudiosbaixados = new conexao();
                criandotabelaaudiosbaixados.executar(query);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ "ERRO na criação da tabela de audio do usuario");
            }




        }

        public void CriandoCaixadeEmailEnviado()
        {
            try
            {
                string query = " CREATE TABLE `hecto042_bookit`.`emailenviado" + login.Text + "` ( `id` INT NOT NULL AUTO_INCREMENT , `LoginDestinatario` VARCHAR(250) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , `EnviarAssunto` VARCHAR(250) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , `EnviarMensagem` LONGTEXT CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`) ) ENGINE = InnoDB CHARACTER SET utf8 COLLATE utf8_general_ci;";
                conexao cxemailsenviados = new conexao();
                cxemailsenviados.executar(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Erro na criação da tabela de Emails Enviados");
            }


        }

        public void CriandoCaixaEmailRecebido()
        {

            try
            {
                string query = "CREATE TABLE `hecto042_bookit`.`emailrecebido" + login.Text + "` ( `id` INT NOT NULL AUTO_INCREMENT , `RemetenteRecebido` VARCHAR(250) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , `AssuntoRecebido` VARCHAR(250) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , `MensagemRecebida` LONGTEXT CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`) ) ENGINE = InnoDB CHARACTER SET utf8 COLLATE utf8_general_ci;";
                conexao cxemailsrecebidos = new conexao();
                cxemailsrecebidos.executar(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "ERRO na criação da tabela da caixa de emails Recebidos");
            }


        }

        public void CriarTabelaProgresso()
        {
            try
            {
                string query = "CREATE TABLE progresso" + confusers.usuario + " ( `id` INT(11) NOT NULL AUTO_INCREMENT , `artigo` VARCHAR(250) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , `tipo` VARCHAR(250) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`) ) ENGINE = InnoDB CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT = 'Informação para barra de progresso';";
                conexao Progressuser = new conexao();
                Progressuser.executar(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "ERRO na criação da tabela Progresso");
            }
        
        
        }


        public void EmailDeBoasVindas()
        {
            
        }

        //Algoritmo para reportar erros
        public void ReportandoErros()
        {


        }





    }
}
