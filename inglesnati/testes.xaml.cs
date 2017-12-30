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
using System.IO;
using MySql.Data.MySqlClient;

namespace inglesnati
{
    /// <summary>
    /// Interaction logic for testes.xaml
    /// </summary>
    public partial class testes : Window
    {
        public testes()
        {
            InitializeComponent();
            Carregarcombo();

        }

        public void Carregarcombo()
        {
            string query = "SELECT AssuntoRecebido from emailrecebidoelena";
            conexao CarregarCB = new conexao();
            var DadosCB = CarregarCB.retornarDados(query);
           
            {
                if (DadosCB.Rows.Count > 0)
                {
                    for (int i = 0; i < DadosCB.Rows.Count; i++)
                    {
                        combobox.Items.Add(DadosCB.Rows[i]["AssuntoRecebido"].ToString());
             
                    }

                }
                else
                {
                    MessageBox.Show("Não há mensagens na caixa de entrada ");
                }
            }
            }


        public void SelectID()
        {
             string constring = confusers.conn;
                string query = "select MensagemRecebida from emailrecebido" + confusers.usuario + " where AssuntoRecebido =@AssuntoRecebido;";

                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(query, conDataBase);
                cmdDataBase.Parameters.AddWithValue("@AssuntoRecebido", combobox.Text);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    while (myReader.Read())
                    {

                        string sMensagemRecebida = myReader.GetString("MensagemRecebida");

                        TBTexto.Text = sMensagemRecebida;
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            
        }





        public void EnviandoAsssuntoParaVariavel()
        {
            confusers.AssuntoRecebido = combobox.Text.ToString();
        }


        public void ShowData()
        {
             string query = "SELECT * FROM emailrecebidoelena where AssuntoRecebido='@AssuntoRecebido';";
            conexao MDados = new conexao();
            var view = MDados.retornarDados(query);
            TBTexto.Text = view.Rows[0]["MensagemRecebida"].ToString();



            
            
        }

        private void BTok_Click(object sender, RoutedEventArgs e)
        {
            SelectID();
            //EnviandoAsssuntoParaVariavel();
            //ShowData();
        }

        private void EnviarTextoParaRichText_Click(object sender, RoutedEventArgs e)
        {

            string arquivo = @"Textos\Texto1.txt";
            var dirtexto = AppDomain.CurrentDomain.BaseDirectory;
                StreamReader reader = new StreamReader(dirtexto + @arquivo);

                RTtexto.Text = "";
                RTtexto.Text = reader.ReadToEnd();
                reader.Close();
              
            
        }



    }
}
