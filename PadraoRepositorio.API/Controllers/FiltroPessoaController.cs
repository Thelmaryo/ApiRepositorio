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
    public class FiltroPessoaController : ControllerBase
    {
        private IPessoaRepositorio repositorio;

        public FiltroPessoaController(IPessoaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: api/FiltroPessoa
        [HttpPost]
        public IEnumerable<Pessoa> Post([FromBody] DataTable datatable)
        {
            return repositorio.Filtrar(datatable );  
        }

    }
}
