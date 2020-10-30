using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using freshdent.Iservices;
using freshdent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace freshdent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedienteController : ControllerBase
    {
        private IExpedienteService _oExpedienteService;
        public ExpedienteController(IExpedienteService oExpedienteService)
        {
            _oExpedienteService = oExpedienteService;
        }

        //GET: api/<ExpedienteController>
        [HttpGet]
        public IEnumerable<Expediente> Get()
        {
            return _oExpedienteService.Gets();
        }

        //GET: api/<ExpedienteController>/5
        [HttpGet("{@id}", Name = "Get")]
        public Expediente Get(int id)
        {
            return _oExpedienteService.Get(id);
        }

        //POST: api/<ExpedienteController>
        [HttpPost]
        public void Post([FromBody] Expediente oExpediente)
        {
            if (ModelState.IsValid) _oExpedienteService.Add(oExpediente);
        }

        //PUT: api/<ExpedienteController>/5
        [HttpPut]
        public void Put([FromBody]Expediente oExpediente)
        {
            if (ModelState.IsValid) _oExpedienteService.Update(oExpediente);
        }

        //DELETE: api/<ExpedienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oExpedienteService.Delete(id);
        }
    }
}
