using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace ImportacaoLista.Conexoes
{
    class Sql
    {

        public readonly SqlConnection _conexao;

        public  Sql()
        {
            string baseDados = File.ReadAllText(@"C:\Users\Nagib\Desktop\LACIR\Base de dados\BasedeDadosConexao.txt");
           _conexao = new SqlConnection(baseDados);

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
