using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Types;
using System.Data;

using System.IO;

namespace inglesnati
{



    class conexao
    {

        //servidor remoto hostgator
        string constring = "Server=;port=3306;Database=;Uid=hecto042;password=;";
        //string constring = "Server=localhost;Port=3306;Database=bookit;Uid=root;password=12domlei;";


        public void executar(string sql)
        {
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand command = new MySqlCommand(sql, conDataBase);
            command.Parameters.AddWithValue("@nomecompleto", confusers.nome);
            command.Parameters.AddWithValue("@email", confusers.email);
            command.Parameters.AddWithValue("@login", confusers.usuario);
            command.Parameters.AddWithValue("@senha", confusers.senha);
            command.Parameters.AddWithValue("@id", confusers.id);
            command.Parameters.AddWithValue("@datacadastro", confusers.MySQLFormatDate);
            command.Parameters.AddWithValue("@LoginDestinatario", confusers.LoginDestinatario);
            command.Parameters.AddWithValue("@EnviarAssunto", confusers.EnviarAssunto);
            command.Parameters.AddWithValue("@EnviarMensagem", confusers.EnviarMensagem);
            //painel Administrativo  GRAMATICA TAB
            command.Parameters.AddWithValue("@TBtitulogramatica", confusers.TBtitulogramatica);
            command.Parameters.AddWithValue("@TBtextogramatica", confusers.TBtextogramatica);
            //painel Administrativo INTERVIEW TAB
            command.Parameters.AddWithValue("@TBtitulointerview", confusers.TBtitulointerview);
            command.Parameters.AddWithValue("@TBtextointerview", confusers.TBtextointerview);
             //painel Administrativo LISTENING TAB
            command.Parameters.AddWithValue("@TBnomelistening", confusers.TBnomelistening);
            command.Parameters.AddWithValue("@TBtextolistening", confusers.TBtextolistening);
            command.Parameters.AddWithValue("@TBlinklistening", confusers.TBlinklistening);
            command.Parameters.AddWithValue("@TBcaminholistening", confusers.TBcaminholistening);
            //painle Administrativo EXPRESSION TAB
            command.Parameters.AddWithValue("@TBtituloexpression", confusers.TBtituloexpression);
            command.Parameters.AddWithValue("@TBtextoexpression", confusers.TBtextoexpression);
            //comandosql
            command.Parameters.AddWithValue("@TBsql", confusers.TBsql);
            //titulo do texto para ler
            command.Parameters.AddWithValue("@CBtituloLeitura", confusers.CBtituloLeitura);
            //Administrativo enviar textos para leitura
            command.Parameters.AddWithValue("@TBtituloexercicioleitura", confusers.TBtituloexercicioleitura);
            command.Parameters.AddWithValue("@TBtextoleitura", confusers.TBtextoleitura);
            command.Parameters.AddWithValue("@TBvocabularioleitura", confusers.TBvocabularioleitura);






            conDataBase.Open();
            command.ExecuteNonQuery();
            conDataBase.Close();
        }


        public DataTable retornarDados(string sql)
        {
            MySqlDataAdapter ad = new MySqlDataAdapter(sql, constring);
            DataTable ds = new DataTable();
            ad.Fill(ds);
            ad.Dispose();
            return ds;
        }


        public int Rows { get; set; }
    }





















    ////class connection
    ////{

    ////    public void executar(string sql)
    ////    {
    ////        string constring = "Server=localhost;Port=3306;Database=bookit;Uid=root;password=12domlei;";

    ////        MySqlConnection conDataBase = new MySqlConnection(constring);
    ////        MySqlCommand command = new MySqlCommand(sql, conDataBase);
    ////        //MySqlDataAdapter da = new MySqlDataAdapter(sql, conDataBase);
    ////        //DataTable dt = new DataTable(dados);
    ////        //da.Fill(dt);
    ////        conDataBase.Open();
    ////        command.ExecuteNonQuery();
    ////        conDataBase.Close();
    ////     }


    ////}
}
