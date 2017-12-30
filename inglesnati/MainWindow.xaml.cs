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
using System.Timers;


namespace inglesnati
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        //Window1 gramatica;

        public MainWindow()
        {
            InitializeComponent();
          
           Progress.ProgressoGramatica();
           Progress.ProgressoExpressoes();
           Progress.ProgressoEntrevistas();
           Progress.ProgressoListening();
           update();

            consultapontosorientado();

            //Mostrando Informações da conta do usuário.
            visuaalizaruser.Text = confusers.usuario;
            mostrarpontos.Text = confusers.pontos.ToString();
            //BARRAS DE PROGRESSO
            PBgrammar.Value = confusers.ProgressGramaticaCalculado;
            PBexpressoes.Value = confusers.ProgressExpressoesCalculado;
            PBinterviews.Value = confusers.ProgressEntrevistasCalculado;
            PBexercicios.Value = 0;
            PBlistening.Value = confusers.ProgressListeningCalculado;
            PBWriting.Value = 0;
            ChecarUsuarioMembro();
           
        }
        public void ChecarUsuarioMembro()
        {
            if (confusers.membro == "Estudante")
            {
               
                administrativo.IsEnabled = false;
            }
            if (confusers.membro == "Admin")
            {

                administrativo.IsEnabled = true;
            }

        }
       
        

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        //Função para listar todas as linhas da tabela artigos
        public void update()
        {
            string query = "select * from artigos ";
            conexao con = new conexao();
            var dados = con.retornarDados(query);


            {
                if (dados.Rows.Count > 0)
                {
                    for (int i = 0; i < dados.Rows.Count; i++)
                    {
                        titulos.Text += (string)dados.Rows[i]["nome"] + "\n";

                    }

                }
                else
                {
                    MessageBox.Show("Não há Registro");
                }
            }

        }

        //TESTE consulta pontos orientado

        public void consultapontosorientado()
        {


            string query = "select pontos from usuarios where nome = '" + confusers.usuario + "' ";
            conexao connn = new conexao();
            var dados = connn.retornarDados(query);
            mostrarpontos.Text = dados.Rows[0]["pontos"].ToString();
            confusers.pontos = Convert.ToInt32(mostrarpontos.Text);
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {



        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Btlista_Click(object sender, RoutedEventArgs e)
        {


        }

        //EVENTOS COMEÇO
        private void chamaformgramatica(object sender, RoutedEventArgs e)
        {
            Grammar gramatica = new Grammar();
            gramatica.Show();

        }

        private void sobreoprograma(object sender, RoutedEventArgs e)
        {
            AboutBox1 sobre = new AboutBox1();
            sobre.Show();
        }

        private void chamaformexpressions(object sender, RoutedEventArgs e)
        {
            expressoes fexpressions = new expressoes();
            fexpressions.Show();
        }

        private void chamaforminterview(object sender, RoutedEventArgs e)
        {
            interview interviews = new interview();
            interviews.Show();
        }

        private void pratiqueexerc(object sender, RoutedEventArgs e)
        {

            testeexercicios pratique = new testeexercicios();
            pratique.Show();

        }


        private void gramm(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("FUNFOU");
        }


        private void chamaformphrasalverbs(object sender, RoutedEventArgs e)
        {

            ListaPhrasalVerbs lista = new ListaPhrasalVerbs();
            lista.Show();
        }


        //EVENTOS  FIM
        public void listamenu_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Update(object sender, RoutedEventArgs e)
        {
            Atualizar up = new Atualizar();
            up.Show();



        }

        ////Sistema de login 
        //public void login()
        //{

        //   try{
        //        string query = "select * from usuarios where nome='" + user.Text + "' and senha='" + senha.Password + "' ;";
        //        conexao fazerlogin = new conexao();
        //        var resultado = fazerlogin.retornarDados(query);


        //        {
        //            if (resultado.Rows.Count > 0)
        //            {
        //                for (int i = 0; i < resultado.Rows.Count; i++)
        //                {

        //                    MessageBox.Show("Bem Vindo");
        //                    confusers.logado = true;
        //                    confusers.usuario = user.Text;


        //                    user.IsEnabled = false;


        //                }

        //            }
        //            else if (resultado.Rows.Count > 1)
        //            {
        //                MessageBox.Show("Usuário ou Senha inválida: Cheque novamente. Usuário não existe");
        //            }
        //            else
        //                MessageBox.Show("Usuário ou Senha inválida...tente novamente");
        //        }
        //}
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Check seu nome usuario e senha." );
        //    }


        //}






        private void Btlogin_Click(object sender, RoutedEventArgs e)
        {

            //login();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CadastroUsers cadastro = new CadastroUsers();
            cadastro.Show();
        }

        private void pratiquelistening(object sender, RoutedEventArgs e)
        {
            Listening ouvir = new Listening();
            ouvir.Show();
        }





        private void versao_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //teladelogin lo = new teladelogin();
            //lo.Show();
            Listening l = new Listening();
            l.Show();

        }


        private void Alterarconfiguracoes(object sender, RoutedEventArgs e)
        {

            Configuracoes configuracoes = new Configuracoes();
            configuracoes.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Testdownload teste = new Testdownload();
            teste.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            testeexercicios l = new testeexercicios();
            l.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            // login();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

       

        private void mensagens(object sender, RoutedEventArgs e)
        {
            mensagens email = new mensagens();
            email.Show();

        }
        private void toprank_Click_1(object sender, RoutedEventArgs e)
        {
            Rank topusuarios = new Rank();
            topusuarios.Show();

        }

        private void BTareadetestes_Click(object sender, RoutedEventArgs e)
        {
            testes um = new testes();
            um.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            
        }

        private void paineladmin(object sender, RoutedEventArgs e)
        {
            PainelAdministrativo panel = new PainelAdministrativo();
            panel.Show();
        }
            
    }

}