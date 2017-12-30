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
using MySql.Data;
using System.IO;


namespace inglesnati
{
    /// <summary>
    /// Interaction logic for Grammar.xaml
    /// </summary>
    public partial class Grammar : Window
    {
        public Grammar()
        {
            InitializeComponent();
             //preencher Combox - com orientação
            //EnvieTitulosparaComboBox();

            //envie p combobox apenas artigos nao lidos
            selecionarartigosnaolidos();

            //Preenche Combobox - sem orientação
            //ComboBoxPreencherArtigosGramatica();
            //Inicializando TBusuariologado  desabilitando para edição.
            TBusuariologado.IsEnabled = false;
            //Mostrando usuario no campo usuario logado
            TBusuariologado.Text = confusers.usuario;
            //mostrando pontos já obtidos quando logado.
            TBpontoshj.Text = confusers.pontos.ToString();


            

        }

        //Combobox para preencher com os dados do DB da tabela artigos onde são gramatica
        //public void ComboBoxPreencherArtigosGramatica()
        //{

        //    string constring = "Server=108.167.132.60;port=3306;Database=hecto042_bookit;Uid=hecto042;password=OwN6j5p70u;";
        //    string Query = "select * from artigos where tipo='Grammar';";
        //    MySqlConnection conDataBase = new MySqlConnection(constring);
        //    MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
        //    MySqlDataReader myReader;
        //    try
        //    {
        //        conDataBase.Open();
        //        myReader = cmdDataBase.ExecuteReader();
        //        while (myReader.Read())
        //        {
        //            string snome = myReader.GetString("nome");
        //            ComboEscolherGrammar.Items.Add(snome);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro Componente Fillcombo - Type");
        //    }
        //}





        //algoritmo dos artigos lidos. Ele criará uma tabela no banco com o nome artigoslidos-usuario com campos id e nome


       

        // algoritmo inserir o nome do artigo na tabela artigoslidos'usuario'
        public void inserirartigoslidos()
        {
            try{
            string query = "INSERT INTO `artigoslidos"+confusers.usuario+"` (`nome`) VALUES ('"+ComboEscolherGrammar.Text+"');";
            conexao inserirartigosligos = new conexao();
            inserirartigosligos.executar(query);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ProgressoUsuario()
        {
            try
            {
                //INSERT IGNORE INTO progressoJoseDomingos (artigo, tipo) VALUES( '" + ComboEscolherGrammar.Text + "', 'gramaticageral');
                //INSERT INTO `hecto042_bookit`.`progressoJoseDomingos` (`artigo`, `tipo`) VALUES ('Report Speed', 'gramaticageral')
                string query = "INSERT IGNORE INTO progresso" + confusers.usuario + " (artigo, tipo) VALUES( '" + ComboEscolherGrammar.Text + "', 'gramaticageral');";
                conexao inserirartigosligos = new conexao();
                inserirartigosligos.executar(query);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Algotimo para checar se o usuario já leu este artigo.
        //public void artigolido()
        //{
        //    string query = "SELECT * from artigoslidos"+confusers.usuario+" where nome='"+ComboEscolherGrammar.Text+"';";
        //    conexao vocejaleuesteartigo = new conexao();
        //    var lido = vocejaleuesteartigo.retornarDados(query);
        //    var selecionado = ComboEscolherGrammar.Text;
        //    if (lido.ToString() == selecionado)
        //    {
        //    MessageBox.Show("Você já leu este artigo e marcou como lido. A opção de marcar como lido será desabilitada.");
        //    }
        //}





        // algoritmo selecionar/mostrar apenas os artigos que não foram lidos pelo usuario.

        public void selecionarartigosnaolidos()
        {
            try
            {
                string query = "SELECT DISTINCT nome FROM artigosgramatica WHERE nome NOT IN (SELECT DISTINCT nome FROM artigoslidos" + confusers.usuario + ");";

                conexao selecionarartidosnlidos = new conexao();
                var dados = selecionarartidosnlidos.retornarDados(query);


                {
                    if (dados.Rows.Count > 0)
                    {
                        for (int i = 0; i < dados.Rows.Count; i++)
                        {
                            ComboEscolherGrammar.Items.Add(dados.Rows[i]["nome"].ToString());

                        }

                    }
                    else
                    {
                        MessageBox.Show("Não há mais artigos nessa sessão para leitura: Vá em configurações > Usuários e resete suas atividades. ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
            }
            

        }


        //preencher o combobox apenas com artigos que não foram lidos pelo usuarios

        public void recarregarselecionarartigosnaolidos()
        {
            try
            {
                string query = "SELECT DISTINCT nome FROM artigosgramatica WHERE nome NOT IN (SELECT DISTINCT nome FROM artigoslidos" + confusers.usuario + ");";
                conexao reloadselecionarartidosnlidos = new conexao();
                var redados = reloadselecionarartidosnlidos.retornarDados(query);

                {
                    if (redados.Rows.Count > 0)
                    {
                        for (int i = 0; i < redados.Rows.Count; i++)

                            ComboEscolherGrammar.Items.Add(redados.Rows[i]["nome"].ToString());
                        {

                        }

                    }
                    else
                    {
                        MessageBox.Show("ERRO - Não foi possivel encontrar dados - select distinct ");
                    }
                }
            }
            

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }







        // Algoritmo  preencher ComboBox com todos os artigos tipo Grammar, inclusive os que já foram lidos.

        public void EnvieTitulosparaComboBox()
        {

            try { 
            string query = "select * from artigos where tipo='Grammar';";
            conexao comboboxgrammar = new conexao();
            var dados = comboboxgrammar.retornarDados(query);


            {
                if (dados.Rows.Count > 0)
                {
                    for (int i = 0; i < dados.Rows.Count; i++)
                    {
                        ComboEscolherGrammar.Items.Add(dados.Rows[i]["nome"].ToString());

                    }

                }
                else
                {
                    MessageBox.Show("ERRO - Não foi possivel encontrar dados na tabela ");
                }
            }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        
        //public void checarartigoslidos()
        //{

        //    string query = "UPDATE usuarios SET pontos = '" + confusers.pontos + "' WHERE nome = '" + confusers.usuario + "';";

        //    conexao checarartigoslidos = new conexao();
        //    checarartigoslidos.executar(query);

        //         checarartigoslidos.retornarDados("artigos");
  
            

        //}



        //Algoritmo para adcionar pontos apenas se o usuario estiver logado e adciona o nome do artigo na tabela artigoslidos


        public void adicionarpontos()
        {
            try
            {
                if (confusers.logado == true)
                {
                    string query = "UPDATE usuarios SET pontos = '" + confusers.pontos + "' WHERE nome = '" + confusers.usuario + "';";
                    conexao conectar = new conexao();
                    conectar.executar(query);
                    inserirartigoslidos();
                }
                else
                {

                    MessageBox.Show("Seus pontos só apareceram nessa sessão, pois você não está logado");
                    //smarcarcheckbox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        
    
       

         //BOTAO DE ESCOLHA DO COMBO BOX ComboEscolherGrammar   e inserir na TBtexto
        private void Btok_Click(object sender, RoutedEventArgs e)
        {

            checkBoxlido.IsChecked = false;
            string query = "select * from artigosgramatica where nome = '" + ComboEscolherGrammar.Text + "' ";
            conexao con = new conexao();
            var selecdados = con.retornarDados(query);


            if (selecdados.Rows.Count > 0)
            {
               TBtexto.Text = (string)selecdados.Rows[0]["conteudo"];
             }
            else
            {
                MessageBox.Show("naoháregistro");
            }
           
            
        }

        //Mostrar pontos obtidos no TBpontos

        public void pontoshj()
        {

            TBpontoshj.Text = confusers.pontos.ToString();

        }


        public void desmarcarcheckbox()
        {
            checkBoxlido.IsEnabled = false;
            //checkBoxlido.IsChecked = false;
        }



         //Evento do checkBoxlido

        private void EventoMarcarComoLido(object sender, RoutedEventArgs e)
        {

             if (checkBoxlido.IsChecked == true)
            {
                
                TBusuariologado.Text = confusers.usuario;
                confusers.lido = true;
                confusers.pontos += 5;
                pontoshj();
                ProgressoUsuario();
                adicionarpontos();
                ComboEscolherGrammar.Items.Clear();
                recarregarselecionarartigosnaolidos();
                
                MessageBox.Show("Passe para o próximo artigo");
                
            }
            else
            {
                confusers.lido = false;
                confusers.pontos += -5;
                pontoshj();
                MessageBox.Show("Você desmarcou a opção");

            }

        }

        private void checkBoxlido_Checked(object sender, RoutedEventArgs e)
        {

        }

                
    }
}
