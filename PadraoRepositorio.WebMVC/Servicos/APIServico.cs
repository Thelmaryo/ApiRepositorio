using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PadraoRepositorio.WebMVC.Servicos
{
    public abstract class APIServico<T>
    {
        protected string prefixo = "https://localhost:44308/api/";
        protected HttpClient client = new HttpClient();

        protected IEnumerable<T> List(string url)
        {
            var result = client.GetAsync(prefixo + url).GetAwaiter().GetResult();
            return result.Content.ReadAsAsync<IEnumerable<T>>().GetAwaiter().GetResult();
        }

        protected T Get(string url)
        {
            var result = client.GetAsync(prefixo + url).GetAwaiter().GetResult();
            return result.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
        }

        protected bool Post(string url, T objeto)
        {
            var result = client.PostAsJsonAsync(prefixo + url, objeto).GetAwaiter().GetResult();
            return result.IsSuccessStatusCode;
        }

        protected bool Put(string url, T objeto)
        {
            var resultado = client.PutAsJsonAsync(prefixo + url, objeto).GetAwaiter().GetResult();
            return resultado.IsSuccessStatusCode;
        }

        protected bool Delete(string url)
        {
            var result = client.DeleteAsync(prefixo + url).GetAwaiter().GetResult();
            return result.IsSuccessStatusCode;
        }
    }
}