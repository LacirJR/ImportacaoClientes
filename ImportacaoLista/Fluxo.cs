using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoLista
{
    class Fluxo
    {
        public void ImportacaoClientes()
        {
            var clientes = new LeituraArquivo();
            clientes.Leitura();
            var sql = new Conexoes.Sql();
            foreach (var cliente in clientes.Leitura())
            {
                bool existencia = sql.VerificarExistencia(cliente.CPF);
                if (existencia == false)
                {
                    sql.InserirBaseDados(cliente);
                } else
                {
                    sql.AtualizarCliente(cliente);
                }

                break;
            }


            
        }
    }
}
