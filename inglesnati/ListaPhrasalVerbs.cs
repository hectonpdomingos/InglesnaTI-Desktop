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
    public partial class ListaPhrasalVerbs : Form
    {
        public ListaPhrasalVerbs()
        {
            InitializeComponent();
            CarregarDataGridView();
        }

        private void BTInfoPV_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phrasal verb- noun, Grammar 1.a combination of verb and one or more adverbial or prepositional particles, take off, bring up, or put up with, functioning  a single semantic unit and often having an idiomatic meaning that could not be predicted from the meanings of the individual parts.");
        }

        public void CarregarDataGridView()
         {

             string conexaopv = confusers.conn;
             MySqlConnection conDataBasepv = new MySqlConnection(conexaopv);
             //MySqlCommand cmdDataBasepv = new MySqlCommand("SELECT Phrasalverb, Explanation, Example FROM listaphrasalverb ;", conDataBasepv);
             MySqlCommand cmdDataBasepv = new MySqlCommand("SELECT Phrasalverb AS Phrasal_Verb, Explanation AS Explicação, Example AS Exemplo FROM listaphrasalverb ;", conDataBasepv);

             try
             {
                 MySqlDataAdapter preencher = new MySqlDataAdapter();
                 preencher.SelectCommand = cmdDataBasepv;
                 DataTable dbdataset = new DataTable();
                 preencher.Fill(dbdataset);
                 BindingSource bSource = new BindingSource();

                 bSource.DataSource = dbdataset;
                 dataGridView1.DataSource = bSource;
                 preencher.Update(dbdataset);


             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }


    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListaPhrasalVerbs_Load(object sender, EventArgs e)
        {

        }
    }
}
