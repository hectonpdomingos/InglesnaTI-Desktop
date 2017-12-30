﻿using System;
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
    /// Interaction logic for expressoes.xaml
    /// </summary>
    public partial class expressoes : Window
    {
        public expressoes()
        {
            InitializeComponent();
           //incializando artigos que não foram lidos
            selecionarartigosnaolidos();

            //Inicializando TBusuariologado  desabilitando para edição.
            TBusuariologado.IsEnabled = false;
            //Mostrando usuario no campo usuario logado
            TBusuariologado.Text = confusers.usuario;
            //mostrando pontos já obtidos quando logado.
            TBpontoshj.Text = confusers.pontos.ToString();
        }

        // algoritmo inserir o nome do artigo na tabela artigoslidos'usuario'
        public void inserirartigoslidos()
        {
            string query = "INSERT INTO `artigoslidos" + confusers.usuario + "` (`nome`) VALUES ('" + ComboEscolherExpressoes.Text + "');";
            conexao inserirartigosligos = new conexao();
            inserirartigosligos.executar(query);
        }


        // algoritmo selecionar/mostrar apenas os artigos que não foram lidos pelo usuario.

        public void selecionarartigosnaolidos()
        {

            string query = "SELECT DISTINCT nome FROM artigosexpressoes WHERE nome NOT IN (SELECT DISTINCT nome FROM artigoslidos" + confusers.usuario + ");";
            conexao selecionarartidosnlidos = new conexao();
            var dados = selecionarartidosnlidos.retornarDados(query);


            {
                if (dados.Rows.Count > 0)
                {
                    for (int i = 0; i < dados.Rows.Count; i++)
                        ComboEscolherExpressoes.Items.Add(dados.Rows[i]["nome"].ToString());
                    {

                    }

                }
                else
                {
                    MessageBox.Show("ERRO - Não foi possivel encontrar dados - select distinct ");
                }
            }


        }

        //preencher o combobox apenas com artigos que não foram lidos pelo usuarios

        public void recarregarselecionarartigosnaolidos()
        {
            string query = "SELECT DISTINCT nome FROM artigosexpressoes WHERE nome NOT IN (SELECT DISTINCT nome FROM artigoslidos" + confusers.usuario + ");";
            conexao reloadselecionarartidosnlidos = new conexao();
            var redados = reloadselecionarartidosnlidos.retornarDados(query);

            {
                if (redados.Rows.Count > 0)
                {
                    for (int i = 0; i < redados.Rows.Count; i++)

                        ComboEscolherExpressoes.Items.Add(redados.Rows[i]["nome"].ToString());
                    {

                    }

                }
                else
                {
                    MessageBox.Show("ERRO - Não foi possivel encontrar dados - select distinct ");
                }
            }


        }



        //#################################################################################//
        public void adicionarpontos()
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
                desmarcarcheckbox();
            }

        }

        public void desmarcarcheckbox()
        {
            checkBoxlido.IsEnabled = false;
            //checkBoxlido.IsChecked = false;
        }



        //Mostrar pontos obtidos no TBpontos

        public void pontoshj()
        {

            TBpontoshj.Text = confusers.pontos.ToString();

        }

        //#################################################################################//


        //Botao ok para selecionar o artigo do combobox  ComcoEscolherEspressoes
        private void Btok_Click(object sender, RoutedEventArgs e)
        {


            checkBoxlido.IsChecked = false;
            string query = "select * from artigosexpressoes where nome = '" + ComboEscolherExpressoes.Text + "' ";
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

        private void Texto_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void ProgressoUsuario()
        {
            try
            {
                //INSERT IGNORE INTO progressoJoseDomingos (artigo, tipo) VALUES( '" + ComboEscolherGrammar.Text + "', 'gramaticageral');
                //INSERT INTO `hecto042_bookit`.`progressoJoseDomingos` (`artigo`, `tipo`) VALUES ('Report Speed', 'gramaticageral')
                string query = "INSERT IGNORE INTO progresso" + confusers.usuario + " (artigo, tipo) VALUES( '" + ComboEscolherExpressoes.Text + "', 'expressoesgeral');";
                conexao inserirartigosligos = new conexao();
                inserirartigosligos.executar(query);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                ComboEscolherExpressoes.Items.Clear();
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






    }
}
