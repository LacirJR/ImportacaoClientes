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
                cliente.CPF = linhaCliente.Substring(0, 11).Trim();
                cliente.Nome = linhaCliente.Substring(11, 80).Trim();
                cliente.Genero = Convert.ToChar(linhaCliente.Substring(91, 1).Trim());
                cliente.Idade = int.Parse(linhaCliente.Substring(92, 3).Trim());
                cliente.Nacionalidade = linhaCliente.Substring(95, 20).Trim();
               

                listaClientes.Add(cliente);
            }


            return listaClientes;

        }
    }
}
