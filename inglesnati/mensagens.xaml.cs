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
    
    //
   
    /// Interaction logic for mensagens.xaml
    /// </summary>
    public partial class mensagens : Window
    {
     
        public mensagens()
        {
            InitializeComponent();
            LerMensagens();
            LoginDestinatario.Text = confusers.LoginDestinatario;
        }



        // Carregar combo Box dos assuntos dos emails recebidos
        public void LerMensagens()
        {
            
            try
            { 
            string query = "SELECT AssuntoRecebido FROM emailrecebido" + confusers.usuario + " ; ";
            conexao EmailsRecebidos = new conexao();
            var mails = EmailsRecebidos.retornarDados(query);
            {
                if (mails.Rows.Count > 0)
                {
                    for (int i = 0; i < mails.Rows.Count; i++)
                    {
                        ComboBoxAssunto.Items.Add(mails.Rows[i]["AssuntoRecebido"].ToString());
             
                    }

                }
                else
                {
                    MessageBox.Show("Não há mensagens na caixa de entrada ");
                }
            }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        public void enviarmsgdestino()
        {

            try
            {
                //  ENVIA A MSG PARA O DESTINATÁRIO
                confusers.LoginDestinatario = LoginDestinatario.Text;
                confusers.EnviarAssunto = EnviarAssunto.Text;
                confusers.EnviarMensagem = EnviarMensagem.Text;
                string query = "INSERT INTO emailrecebido" + confusers.LoginDestinatario + "(RemetenteRecebido, AssuntoRecebido,  MensagemRecebida) values(@LoginDestinatario, @EnviarAssunto, @EnviarMensagem);";
                conexao SendMessage = new conexao();
                SendMessage.executar(query);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + "Erro ao enviar a Mensagem");
            }
            MessageBox.Show("Mensagem Enviada!");
        }

       
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            enviarmsgdestino();
           
        }

        public void DefinindoAssunto()
        {

        }
        public void showmsg()
        {

            
            confusers.AssuntoRecebido = ComboBoxAssunto.Text;
            string query = "SELECT MensagemRecebida FROM emailrecebido" + confusers.usuario + " WHERE AssuntoRecebido=@AssuntoRecebido; ";
            conexao MDadosmail = new conexao();
            var viewmail = MDadosmail.retornarDados(query);
            TBMsgRecebida.Text = viewmail.ToString();
            
        }


      
        // COGIDOS  DA TAB DE RECEBIMENTO DE MENSAGEMS   - OBS  NAO ESTA PARAMETRADO- RESOLVER O QUANTO ANTES
        public void ExibirCorpoDaMensagem()
        {



            {
                string constring = confusers.conn;
                string query = "select * from emailrecebido" + confusers.usuario + " where AssuntoRecebido =@AssuntoRecebido;";

                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(query, conDataBase);
                cmdDataBase.Parameters.AddWithValue("@AssuntoRecebido", ComboBoxAssunto.Text);
                MySqlDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    while (myReader.Read())
                    {
              
                        string sMensagemRecebida = myReader.GetString("MensagemRecebida");
                        confusers.MensagemRecebida = myReader.GetString("MensagemRecebida");
                        confusers.AssuntoRecebido = myReader.GetString("AssuntoRecebido");
                        confusers.id = myReader.GetInt32("id");
                        confusers.LoginDestinatario = myReader.GetString("RemetenteRecebido");
                        //MessageBox.Show("msg: " + confusers.id);
                        TBMsgRecebida.Text += "Remetente:  " + confusers.LoginDestinatario.ToString() + "\n";
                        TBMsgRecebida.Text += "" + "\n";
                        TBMsgRecebida.Text += "" + "\n";
                        TBMsgRecebida.Text += sMensagemRecebida;
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                conDataBase.Close();
            }



        }

      
        //botao de ler msg
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //showmsg();
            //ExibirMSGReplace();
            ExibirCorpoDaMensagem();
            //LerMensagem.Background = Brushes.Blue;
            // msdn.microsoft.com/en-us/library/system.windows.media.brushes.aspx
           
           
            //GetMenagem();
           // ShowMensage();

        }

        private void BTexcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string constring = confusers.conn;
                string query = "DELETE FROM emailrecebido"+confusers.usuario+" WHERE id='"+confusers.id+"';";
                conexao deleemail = new conexao();
                deleemail.executar(query);
                ComboBoxAssunto.Items.Clear();
                TBMsgRecebida.Text = " ";
                LerMensagens();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

     
    }
}
