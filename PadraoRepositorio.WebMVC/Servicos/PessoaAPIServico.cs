using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PadraoRepositorio.WebMVC.Servicos
{
    public class PessoaAPIServico : APIServico<Pessoa>
    {
        public IEnumerable<Pessoa> Listar()
        {
            return List("v1/Pessoa");
        }

        public Pessoa BuscarPorId(int id)
        {
            return Get($"v1/Pessoa/{id}");
        }

        public IEnumerable<Pessoa> Filtrar(DataTable datatable)
        {
            var result = client.PostAsJsonAsync(prefixo + "v1/FiltroPessoa", datatable).GetAwaiter().GetResult();
            return result.Content.ReadAsAsync<IEnumerable<Pessoa>>().GetAwaiter().GetResult();
        }

        public bool Salvar(Pessoa pessoa)
        {
            return Post("v1/Pessoa", pessoa);
        }

        public bool Atualizar(Pessoa pessoa)
        {
            return Put("v1/Pessoa", pessoa);
        }

        public bool Excluir(int id)
        {
            return Delete($"v1/Pessoa/{id}");
        }
    }
}