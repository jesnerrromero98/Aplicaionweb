using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using freshdent.Iservicies;
using freshdent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace freshdent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaService _oConsultaService;
        public ConsultaController(IConsultaService oConsultaServicie)
        {
            _oConsultaService = oConsultaServicie;
        }
        // GET: api/<EmpleadosController>
        [HttpGet]
        public IEnumerable<Consulta> Get()
        {
            return _oConsultaService.Gets();
        }
        // GET api/<EmpleadosController>/5
        [HttpGet("{id}", Name = "Get")]
        public Consulta Get(int id)
        {
            return _oConsultaService.Get(id);
        }
        // POST api/<EmpleadosController>

        [HttpPost]
        public void Post([FromBody] Consulta oConsulta)
        {
            if (ModelState.IsValid) _oConsultaService.Add(oConsulta);
        }
        // PUT api/<EmpleadosController>/5
        [HttpPut]
        public void Put([FromBody] Consulta oConsulta)
        {
            if (ModelState.IsValid) _oConsultaService.update(oConsulta);
        }
        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oConsultaService.Delete(id);
        }
    }

}
