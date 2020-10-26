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
    public class ExpedienteController : ControllerBase
    {
        private IExpedienteServicie _oExpedienteService;
        public ExpedienteController(IExpedienteServicie oExpedienteServicie)
        {
            _oExpedienteService = oExpedienteServicie;
        }
        // GET: api/<EmpleadosController>
        [HttpGet]
        public IEnumerable<Expediente> Get()
        {
            return _oExpedienteService.Gets();
        }
        // GET api/<EmpleadosController>/5
        [HttpGet("{id}", Name = "Get")]
        public Expediente Get(int id)
        {
            return _oExpedienteService.Get(id);
        }
        // POST api/<EmpleadosController>

        [HttpPost]
        public void Post([FromBody] Expediente oEmpleado)
        {
            if (ModelState.IsValid) _oExpedienteService.Add(oEmpleado);
        }
        // PUT api/<EmpleadosController>/5
        [HttpPut]
        public void Put([FromBody] Expediente oExpediente)
        {
            if (ModelState.IsValid) _oExpedienteService.update(oExpediente);
        }
        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oExpedienteService.Delete(id);
        }
    }

}