using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PadraoRepositorio.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IPessoaRepositorio repositorio;

        public PessoaController(IPessoaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: api/Pessoa
        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            return repositorio.Listar();
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}")]
        public Pessoa Get(int id)
        {
            return repositorio.BuscarPorId(id);
        }

        // POST: api/Pessoa
        [HttpPost]
        public void Post([FromBody] Pessoa pessoa)
        {
            repositorio.Cadastrar(pessoa);
        }

        // PUT: api/Pessoa/5
        [HttpPut]
        public void Put([FromBody] Pessoa pessoa)
        {
            repositorio.Atualizar(pessoa);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repositorio.Excluir(id);
        }
    }
}
