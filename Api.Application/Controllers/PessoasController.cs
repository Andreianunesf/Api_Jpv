using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace application.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private IPessoaService _service;
        public PessoasController(IPessoaService pessoaService)
        {
            _service = pessoaService;
        }

        [HttpGet] 
        public async Task<ActionResult> GetAll([FromServices] IPessoaService service) // select * from table
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet] 
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id) 
        {
            return Ok(await _service.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Pessoa p) 
        {
            var select = await _service.Post(p);
            return Created(new Uri(Url.Link("GetWithId", new { id = select.Id })), select); 

        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Pessoa p) 
        {
            var update = await _service.Put(p);
            return Ok(update);  
        }
        [HttpDelete ("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
