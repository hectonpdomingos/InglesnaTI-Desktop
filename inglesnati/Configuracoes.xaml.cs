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
using System.Media;



namespace inglesnati
{
    /// <summary>
    /// Interaction logic for Configuracoes.xaml
    /// </summary>
    public partial class Configuracoes : Window
    {
        public Configuracoes()
        {
            InitializeComponent();
            MostrarUsuario();
        }

        //Mostrar dados cadastrados do usuário. Alteração apenas da senha

        public void MostrarUsuario()
        {
            string query = "SELECT id, nomecompleto, email, nome, senha FROM usuarios where nome='" + confusers.usuario + "';";
            conexao MDados = new conexao();
            var view = MDados.retornarDados(query);
            nomecompleto.Text = view.Rows[0]["nomecompleto"].ToString();
            email.Text = view.Rows[0]["email"].ToString();
            login.Text = view.Rows[0]["nome"].ToString();
            senha.Password = view.Rows[0]["senha"].ToString();
            confusers.id = Convert.ToInt32(view.Rows[0]["id"]);
        }

        //


        //

        private void resetartudo(object sender, RoutedEventArgs e)
        {
            string query = "TRUNCATE TABLE artigoslidos" + confusers.usuario + "";
            conexao deletarregistrosdelidos = new conexao();
            deletarregistrosdelidos.executar(query);
            MessageBox.Show("Todos os artigos foram liberados");
            if (lerdepois.IsChecked == true)
            {
                confusers.permitirlerdepois = 1;
            }
            else
            {
                confusers.permitirlerdepois = 0;
            }

        }
        //ATUALIZA DADOS
        private void cadastrarusuario(object sender, RoutedEventArgs e)
        {
            confusers.nome = nomecompleto.Text;
            confusers.email = email.Text;
            confusers.usuario = login.Text;          
            confusers.senha = senha.Password.ToString();

            string query = "UPDATE usuarios SET nomecompleto=@nomecompleto, email=@email, nome=@login, senha=@senha WHERE id=@id ;";
            conexao cadastrarusuario = new conexao();
            cadastrarusuario.executar(query);
            criartabelaartigoslidos();
            
            MessageBox.Show("Cadastro Alterado com sucesso!");

            Close();


        }

        public void criartabelaartigoslidos()
        {

            string query = "CREATE TABLE IF NOT EXISTS `artigoslidos" + login.Text + "` (`id` INT(11) NOT NULL AUTO_INCREMENT,`nome` VARCHAR(250) NULL,	PRIMARY KEY (`id`),	UNIQUE INDEX `id` (`id`))COLLATE='utf8_general_ci'ENGINE=InnoDB;";
            conexao criartabelaartigoslidosusuario = new conexao();
            criartabelaartigoslidosusuario.executar(query);


        }





    }
}
