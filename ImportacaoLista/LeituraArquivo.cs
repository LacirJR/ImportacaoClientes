using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoLista
{
    public class LeituraArquivo
    {
        public List<Entidades.Clientes> Leitura()
        {
            var listaClientes = new List<Entidades.Clientes>();
            var linhasClientes = File.ReadAllLines(@"C:\Users\Nagib\Desktop\Exercicios\Sala de aula\17-01-2022\Clientes.txt", Encoding.UTF8);
           


            foreach (string linhaCliente in linhasClientes)
            {
                var cliente = new Entidades.Clientes();
                cliente.CPF = linhaCliente.Substring(0, 11);
                cliente.Nome = linhaCliente.Substring(11, 80);
                cliente.Genero = Convert.ToChar(linhaCliente.Substring(91, 1));
                cliente.Idade = int.Parse(linhaCliente.Substring(92, 3));
                cliente.Nacionalidade = linhaCliente.Substring(95, 20);
               

                listaClientes.Add(cliente);
            }


            return listaClientes;

        }
    }
}
