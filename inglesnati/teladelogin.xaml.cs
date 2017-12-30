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
using System.Net;
using System.Net.NetworkInformation;

namespace inglesnati
{
    /// <summary>
    /// Interaction logic for teladelogin.xaml
    /// </summary>
    public partial class teladelogin : Window
    {
        public teladelogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            CadastroUsers cad = new CadastroUsers();
            cad.Show();
        }

        public void Membro()
        {
            string query = "select tipodeconta from usuarios where nome='" + nome.Text + "' and senha='" + senha.Password + "' ;";
            conexao fazerlogin = new conexao();
            var membro = fazerlogin.retornarDados(query);
            confusers.membro = membro.Rows[0]["tipodeconta"].ToString();
        }
        public void login()
        {

            try
            {

                //SELECT * FROM `usuarios` WHERE nome='JoseDomingos' and senha='domlei'

            string query = "select nome, senha, tipodeconta from usuarios where nome='" + nome.Text + "' and senha='" + senha.Password + "' ;";
                conexao fazerlogin = new conexao();
                var resultado = fazerlogin.retornarDados(query);


                {
                    if (resultado.Rows.Count > 0)
                    {
                        for (int i = 0; i < resultado.Rows.Count; i++)
                        {

                            confusers.logado = true;
                            confusers.usuario = nome.Text;
                            nome.Text = confusers.usuario;
                            nome.IsEnabled = false;
                            Membro();
                            MainWindow telaprincipal = new MainWindow();
                            telaprincipal.Show();
                            Close();


                        }

                    }
                    else if (resultado.Rows.Count > 1)
                    {
                        MessageBox.Show("Usuário ou Senha inválida: Cheque novamente. Usuário não existe");
                    }
                    else
                        MessageBox.Show("Usuário ou Senha inválida...tente novamente");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Check seu nome usuario e senha.");
            }


        }

        public void InformacaoDoUsuario()
        {
            foreach (NetworkInterface netif in NetworkInterface.GetAllNetworkInterfaces())
            {
                MessageBox.Show("Network Interface: {0}", netif.Name);
                IPInterfaceProperties properties = netif.GetIPProperties();
                foreach (IPAddress dns in properties.DnsAddresses)
                    MessageBox.Show("\tDNS: {0}"+ dns);
                foreach (IPAddressInformation anycast in properties.AnycastAddresses)
                    MessageBox.Show("\tAnyCast: {0}"+ anycast.Address);
                foreach (IPAddressInformation multicast in properties.MulticastAddresses)
                    MessageBox.Show("\tMultiCast: {0}"+ multicast.Address);
                foreach (IPAddressInformation unicast in properties.UnicastAddresses)
                    MessageBox.Show("\tUniCast: {0}"+ unicast.Address);
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            login();
        }
    }
}
