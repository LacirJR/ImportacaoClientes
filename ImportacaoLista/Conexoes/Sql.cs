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

        public bool VerificarExistencia(string cpf)
        {
            bool existencia = false;
            try
            {
                _conexao.Open();
                string sql = "select Count(Cpf) AS total from Cliente WHERE Cpf = @Cpf;";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("Cpf", cpf);
                    cmd.ExecuteScalar();
                    int scalar = Convert.ToInt32(cmd.ExecuteScalar());
                   if (scalar > 0)
                        existencia = true;

                }

            }
            finally
            {
                _conexao.Close();
            }

            return existencia;
        }

        public void AtualizarCliente(Entidades.Clientes cliente)
        {
            string cpf = cliente.CPF;
            string nome = cliente.Nome;
            int idade = cliente.Idade;
            char genero = cliente.Genero;
            string nacionalidade = cliente.Nacionalidade;
            

            Console.WriteLine("Deseja Atualizar o cliente? S/N");
            string confirmacao = Console.ReadLine();

            if (confirmacao == "S")
            {
                Console.WriteLine("Qual o CPF do usuario a ser atualizado?");
                cpf = Console.ReadLine();

                Console.WriteLine("O que deseja atualizar? \n1 - Nome\n2 - Idade\n3 - Genero\n4 - Nacionalidade\n5 - Atualizar tudo");
                int opcao = int.Parse(Console.ReadLine());
                Console.Clear();
                //ESCOLHER QUAL VALOR ATUALIZAR
                switch (opcao)
                {
                    case 1: //NOME
                        Console.Write("Digite o novo valor para nome: ");
                        nome = Console.ReadLine();
                        AtualizarClienteNome(cpf, nome);
                        break;
                    case 2: // IDADE
                        Console.Write("Digite o novo valor para Idade: ");
                        idade = int.Parse(Console.ReadLine());
                        AtualizarClienteIdade(cpf, idade);
                        break;
                    case 3: // GENERO
                        Console.Write("Digite o novo valor para Genero (M ou F): ");
                        genero = char.Parse(Console.ReadLine());
                        AtualizarClienteGenero(cpf, genero);
                        break;
                    case 4: // NACIONALIDADE
                        Console.Write("Digite o novo valor para Nacionalidade: ");
                        nacionalidade = Console.ReadLine();
                        AtualizarClienteNacionalidade(cpf, nacionalidade);
                        break;
                    case 5: // TODOS OS VALORES
                        Console.Write("Digite o novo valor para nome: ");
                        nome = Console.ReadLine();

                        Console.Write("Digite o novo valor para Idade: ");
                        idade = int.Parse(Console.ReadLine());

                        Console.Write("Digite o novo valor para Genero (M ou F): ");
                        genero = char.Parse(Console.ReadLine());
                        
                        Console.Write("Digite o novo valor para Nacionalidade: ");
                        nacionalidade = Console.ReadLine();

                        AtualizarClienteTodos(cpf, nome, idade, genero, nacionalidade);
                        break;
                    default:
                        break;
                }
            }
            else;
        }

        public void AtualizarClienteNome(string cpf, string nome)
        {
            try
            {
                _conexao.Open();
                string sql = @"UPDATE Cliente
                                   SET Nome = @Nome
                                      
                                 WHERE Cpf = @Cpf";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("Cpf", cpf.Trim());
                    cmd.Parameters.AddWithValue("Nome", nome.Trim());
                    
                    cmd.ExecuteNonQuery();
                }

            }
            finally
            {
                _conexao.Close();
            }
        }

        public void AtualizarClienteIdade(string cpf, int idade)
        {
            try
            {
                _conexao.Open();
                string sql = @"UPDATE Cliente
                                   SET Idade = @Idade
                                      
                                 WHERE Cpf = @Cpf";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("Cpf", cpf.Trim());
                    cmd.Parameters.AddWithValue("Idade", idade);

                    cmd.ExecuteNonQuery();
                }

            }
            finally
            {
                _conexao.Close();
            }

        }

        public void AtualizarClienteGenero(string cpf, char genero)
        {
            try
            {
                _conexao.Open();
                string sql = @"UPDATE Cliente
                                   SET Genero = @Genero
                                      
                                 WHERE Cpf = @Cpf";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("Cpf", cpf.Trim());
                    cmd.Parameters.AddWithValue("Genero", genero);

                    cmd.ExecuteNonQuery();
                }

            }
            finally
            {
                _conexao.Close();
            }
        }

        public void AtualizarClienteNacionalidade(string cpf, string nacionalidade)
        {
            try
            {
                _conexao.Open();
                string sql = @"UPDATE Cliente
                                   SET Nacionalidade = @Nacionalidade
                                      
                                 WHERE Cpf = @Cpf";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("Cpf", cpf.Trim());
                    cmd.Parameters.AddWithValue("Nacionalidade", nacionalidade.Trim());

                    cmd.ExecuteNonQuery();
                }

            }
            finally
            {
                _conexao.Close();
            }
        }

        public void AtualizarClienteTodos(string cpf,string nome, int idade, char genero, string nacionalidade)
        {
            try
            {
                _conexao.Open();
                string sql = @"UPDATE Cliente
                                   SET Nome = @Nome
                                      , Genero = @Genero
                                      , Nacionalidade = @Nacionalidade
                                      , Idade = @Idade
                                 WHERE Cpf = @Cpf";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("Cpf", cpf.Trim());
                    cmd.Parameters.AddWithValue("Nome", nome.Trim());
                    cmd.Parameters.AddWithValue("Idade", idade);
                    cmd.Parameters.AddWithValue("Genero", genero);
                    cmd.Parameters.AddWithValue("Nacionalidade", nacionalidade.Trim());
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
