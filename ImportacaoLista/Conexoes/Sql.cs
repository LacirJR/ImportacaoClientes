using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ImportacaoLista.Conexoes
{
    class Sql
    {

        public SqlConnection _conexao;

        public  Sql()
        {
            this._conexao = new SqlConnection(@"Server=192.168.18.238;Database=aluno_01;User Id=aluno;Password=123456;");

        }
        
        public void InserirBaseDados(Entidades.Clientes clientes)
        { 
            try
            {
                _conexao.Open();
                string sql = "INSERT INTO Cliente (Nome , Cpf , Idade, Genero, Nacionalidade) " +
                    "VALUES (@nome , @cpf, @idade, @genero, @nacionalidade);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("nome", clientes.Nome);
                    cmd.Parameters.AddWithValue("cpf", clientes.CPF);
                    cmd.Parameters.AddWithValue("idade", clientes.Idade);
                    cmd.Parameters.AddWithValue("genero", clientes.Genero);
                    cmd.Parameters.AddWithValue("nacionalidade", clientes.Nacionalidade);
                    cmd.ExecuteNonQuery();
                }

            }
            finally
            {
                _conexao.Close();
            }
        }
    }
}
