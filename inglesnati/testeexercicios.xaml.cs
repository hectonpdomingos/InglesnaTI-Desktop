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
    /// <summary>
    /// Interaction logic for testeexercicios.xaml
    /// </summary>
    public partial class testeexercicios : Window
    {
        private int posicaoRegistro = 0;
        private int posicaoRegistrodois = 0;

        public testeexercicios()
        {
            InitializeComponent();
            //LimiteContador();

            textoaleatorio();
            PreencherPhrasalverbDefinicao();
            PreencherCombosRelacionar();
            //carregar titulos no combobox do exercicio de leitura
            CarregarTextosLeitura();



        }

        public void CarregarTextosLeitura()
        {
            try
            {
                string query = "SELECT titulo FROM textos ;";
                conexao conexaoler = new conexao();
                var lertitulo = conexaoler.retornarDados(query);
                //frase1.Items.Clear();

                if (lertitulo.Rows.Count > 0)
                {
                    for (int t = 0; t < lertitulo.Rows.Count; t++)
                    {
                        ComboBoxEscolherLeitura.Items.Add(lertitulo.Rows[t]["titulo"]);

                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERRO  " + ex.Message);
            }
        }




        //######Começo do exercicio REORGANIZAR ////#######
        public void textoaleatorio()
        {
            //opção de query para modo aleatório
            //  select * from phrasalverbs where id > 2 and id < 6  order by rand(); 

            //query original
            string query = "SELECT frase FROM exercicioorganizartexto ORDER BY RAND();";
            conexao organizar = new conexao();
            var organize = organizar.retornarDados(query);
            int i = 0;

            for (i = 0; i < 10; i++)
            {


                frase1.Items.Add(organize.Rows[i]["frase"].ToString());
                frase2.Items.Add(organize.Rows[i]["frase"].ToString());
                frase3.Items.Add(organize.Rows[i]["frase"].ToString());
                frase4.Items.Add(organize.Rows[i]["frase"].ToString());
                frase5.Items.Add(organize.Rows[i]["frase"].ToString());
                frase6.Items.Add(organize.Rows[i]["frase"].ToString());
                frase7.Items.Add(organize.Rows[i]["frase"].ToString());
                frase8.Items.Add(organize.Rows[i]["frase"].ToString());
                frase9.Items.Add(organize.Rows[i]["frase"].ToString());
                frase10.Items.Add(organize.Rows[i]["frase"].ToString());


            }


        }

        public void resposta()
        {

            string query = "SELECT frase FROM exercicioorganizartexto ;";
            conexao respostaorganizada = new conexao();
            var organize = respostaorganizada.retornarDados(query);
            //frase1.Items.Clear();

            if (organize.Rows.Count > 0)
            {
                for (int h = 0; h < organize.Rows.Count; h++)
                {
                    texto.Text += (string)organize.Rows[h]["frase"] + "\n";

                }

            }

        }

        private void BTresposta_Click(object sender, RoutedEventArgs e)
        {
            resposta();
        }
        //###############FIM DO COGIGO DE REORGANIZAR //##################

        //###############COMEÇO DO COGIGO DE RELACIONAR //##################

        public void PreencherCombosRelacionar()
        {

            try
            {
                //string query = "select phrasalverb from phrasalverbs where id >=" + confusers.min + " and id <= " + confusers.max + "  order by rand();";

                string sql = "select aleatorio from phrasalverbs limit " + posicaoRegistro + ",11;";


                conexao buscarphrasalverbs = new conexao();
                var organizecombo = buscarphrasalverbs.retornarDados(sql);
                int j = 0;

                int contador = 0;

                if (organizecombo.Rows.Count == 11)
                {
                    contador = 11;
                }
                else
                {
                    contador = organizecombo.Rows.Count;
                }


                for (j = 0; j < contador; j++)
                {

                    if (contador > 0)
                    {
                        phrasalverb1.Items.Add(organizecombo.Rows[j]["aleatorio"].ToString());

                    }
                    else
                    {
                        phrasalverb1.IsEnabled = false;
                    }

                    if (contador > 1)
                    {
                        phrasalverb2.Items.Add(organizecombo.Rows[j]["aleatorio"].ToString());

                    }
                    else
                    {
                        phrasalverb2.IsEnabled = false;
                    }


                    if (contador > 2)
                    {
                        phrasalverb3.Items.Add(organizecombo.Rows[j]["aleatorio"].ToString());

                    }
                    else
                    {
                        phrasalverb3.IsEnabled = false;
                    }


                    if (contador > 3)
                    {
                        phrasalverb4.Items.Add(organizecombo.Rows[j]["aleatorio"].ToString());

                    }
                    else
                    {
                        phrasalverb4.IsEnabled = false;
                    }


                    if (contador > 4)
                    {
                        phrasalverb5.Items.Add(organizecombo.Rows[j]["aleatorio"].ToString());

                    }
                    else
                    {
                        phrasalverb5.IsEnabled = false;
                    }



                    if (contador > 5)
                    {
                        phrasalverb6.Items.Add(organizecombo.Rows[j]["aleatorio"].ToString());

                    }

                    else
                    {
                        phrasalverb6.IsEnabled = false;
                    }

                    if (contador > 6)
                    {
                        phrasalverb7.Items.Add(organizecombo.Rows[j]["aleatorio"].ToString());

                    }
                    else
                    {
                        phrasalverb7.IsEnabled = false;
                    }
                    if (contador > 7)
                    {
                        phrasalverb8.Items.Add(organizecombo.Rows[j]["aleatorio"].ToString());

                    }

                    else
                    {
                        phrasalverb8.IsEnabled = false;
                    }


                    if (contador > 8)
                    {
                        phrasalverb9.Items.Add(organizecombo.Rows[j]["aleatorio"].ToString());

                    }
                    else
                    {
                        phrasalverb9.IsEnabled = false;
                    }



                    if (contador > 9)
                    {
                        phrasalverb10.Items.Add(organizecombo.Rows[j]["aleatorio"].ToString());

                    }
                    else
                    {
                        phrasalverb10.IsEnabled = false;
                    }


                    if (contador > 10)
                    {
                        phrasalverb11.Items.Add(organizecombo.Rows[j]["aleatorio"].ToString());

                    }
                    else
                    {
                        phrasalverb11.IsEnabled = false;
                    }

                    posicaoRegistro++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            posicaoRegistro--;
        }






        public void PreencherPhrasalverbDefinicao()
        {

            //  select * from phrasalverbs where id > 2 and id < 6  order by rand(); 

            try
            {




                //string query = "SELECT definition FROM phrasalverbs where id >=" + confusers.min + " and id <= " + confusers.max + ";";
                string sql = "SELECT definition FROM phrasalverbs LIMIT " + posicaoRegistrodois + ",11";


                conexao organizar = new conexao();
                var organize = organizar.retornarDados(sql);
                int y = 0;

                int contadordois = 0;

                if (organize.Rows.Count == 11)
                {
                    contadordois = 11;
                }
                else
                {
                    contadordois = organize.Rows.Count;
                }



                for (y = 0; y < contadordois; y++)
                {

                    if (contadordois > 0)
                    {
                        phresposta1.Text = (organize.Rows[0]["definition"].ToString());
                    }
                    else
                    {
                        phresposta1.IsEnabled = false;
                    }



                    if (contadordois > 1)
                    {

                        phresposta2.Text = (organize.Rows[1]["definition"].ToString());
                    }
                    else
                    {
                        phresposta2.IsEnabled = false;
                    }




                    if (contadordois > 2)
                    {

                        phresposta3.Text = (organize.Rows[2]["definition"].ToString());
                    }
                    else
                    {
                        phresposta3.IsEnabled = false;
                    }


                    if (contadordois > 3)
                    {

                        phresposta4.Text = (organize.Rows[3]["definition"].ToString());
                    }
                    else
                    {
                        phresposta4.IsEnabled = false;
                    }





                    if (contadordois > 4)
                    {
                        phresposta5.Text = (organize.Rows[4]["definition"].ToString());
                    }

                    else
                    {
                        phresposta5.IsEnabled = false;
                    }


                    if (contadordois > 5)
                    {
                        phresposta6.Text = (organize.Rows[5]["definition"].ToString());
                    }
                    else
                    {
                        phresposta6.IsEnabled = false;
                    }


                    if (contadordois > 6)
                    {
                        phresposta7.Text = (organize.Rows[6]["definition"].ToString());
                    }
                    else
                    {
                        phresposta7.IsEnabled = false;
                    }

                    if (contadordois > 7)
                    {
                        phresposta8.Text = (organize.Rows[7]["definition"].ToString());

                    }
                    else
                    {
                        phresposta8.IsEnabled = false;
                    }


                    if (contadordois > 8)
                    {
                        phresposta9.Text = (organize.Rows[8]["definition"].ToString());
                    }
                    else
                    {
                        phresposta9.IsEnabled = false;
                    }


                    if (contadordois > 9)
                    {
                        phresposta10.Text = (organize.Rows[9]["definition"].ToString());
                    }
                    else
                    {
                        phresposta10.IsEnabled = false;
                    }


                    if (contadordois > 10)
                    {
                        phresposta11.Text = (organize.Rows[10]["definition"].ToString());

                    }
                    else
                    {
                        phresposta11.IsEnabled = false;
                    }


                    posicaoRegistrodois++;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            posicaoRegistrodois--;
        }


        //MOSTRANDO RESULTADO E CONTABILIZANDO NA CONTA DO USUARIO





        //###################### FIM CONTAGEM DE PONTOS #######################//



        //LIMPANDO TODOS OS CAMPOS
        public void LimpandoTodosCamposExercicioRelacionar()
        {



            //Limpando o ComboBox phrasalverb

            phrasalverb1.Items.Clear();
            phrasalverb2.Items.Clear();
            phrasalverb3.Items.Clear();
            phrasalverb4.Items.Clear();
            phrasalverb5.Items.Clear();
            phrasalverb6.Items.Clear();
            phrasalverb7.Items.Clear();
            phrasalverb8.Items.Clear();
            phrasalverb9.Items.Clear();
            phrasalverb10.Items.Clear();
            phrasalverb11.Items.Clear();
            //Limpando TEXTBOX
            phresposta1.Text = "";
            phresposta2.Text = "";
            phresposta3.Text = "";
            phresposta4.Text = "";
            phresposta5.Text = "";
            phresposta6.Text = "";
            phresposta7.Text = "";
            phresposta8.Text = "";
            phresposta9.Text = "";
            phresposta10.Text = "";
            phresposta11.Text = "";

        }


        //Contado quantas linhas ROWS tem na tabela para definir o limite no confusers.max
        public void LimiteContador()
        {
            String query = "SELECT COUNT(*) FROM phrasalverbs;";
            conexao QtaLinhas = new conexao();
            var limite = QtaLinhas.retornarDados(query);

            confusers.max = Convert.ToInt32(limite.Rows[0][0]);


        }







        //Botão de PRÓXIMO do exericio Relacionar phrasalverbs
        private void BTproximo_Click(object sender, RoutedEventArgs e)
        {


        }

        private void BTproximorelacionar_Click(object sender, RoutedEventArgs e)
        {

            //17-10= 7  17
            //int next = confusers.min + 10;
            //confusers.min = next;
            LimpandoTodosCamposExercicioRelacionar();
            PreencherCombosRelacionar();
            PreencherPhrasalverbDefinicao();

        }

        private void BTanteriorrelacionar_Click(object sender, RoutedEventArgs e)
        {
            int next = confusers.max - 10;
            confusers.min = next;
            LimpandoTodosCamposExercicioRelacionar();
            PreencherCombosRelacionar();
            PreencherPhrasalverbDefinicao();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MostrarResultados();
        }

        private void MostrarResultados()
        {
            throw new NotImplementedException();
        }


        //passando os dados para a variavel
        public void MostrandoTexto()
        {
            {
                string combo = ComboBoxEscolherLeitura.Text;
                string constring = confusers.conn;
                string query = "SELECT texto, vocabulario FROM textos WHERE titulo=@CBtituloLeitura ;";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(query, conDataBase);
                cmdDataBase.Parameters.AddWithValue("@CBtituloLeitura", combo);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    while (myReader.Read())
                    {

                        string sTexto = myReader.GetString("texto");
                       var sVocab = myReader.GetString("vocabulario");
                       // confusers.TextoLeitura = myReader.GetString("texto");
                        TBtextoLeitura.Text = sTexto.ToString();
                        LBvocabulario.Text =  sVocab.ToString();
                    }
                    
                }

                catch (MySqlException ex)
                {
                    MessageBox.Show("ERRO " + ex.Message);
                }
                conDataBase.Close();
            }
          
        }

        //Botao para escolher texto para a leitura
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MostrandoTexto();
        }
    }
}