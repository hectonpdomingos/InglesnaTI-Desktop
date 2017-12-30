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

namespace inglesnati
{
    public partial class Rank : Form
    {
        public Rank()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CarregarTabela();
        }

        private void Rank_Load(object sender, EventArgs e)
        {

        }

        public void CarregarTabela()
        {




            string conexaodb = confusers.conn;
            MySqlConnection conDataBase = new MySqlConnection(conexaodb);
            MySqlCommand cmdDataBase = new MySqlCommand("SELECT nome AS Nome, pontos AS Pontuação, tipodeconta AS Grupo FROM usuarios ORDER BY pontos DESC;", conDataBase);

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
 
       
       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            confusers.LoginDestinatario = dr.Cells[0].Value.ToString();
            mensagens enviarmsg = new mensagens();
            enviarmsg.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
