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
        public IEnumerable<Expediente> ExpedienteGet()
        {
            return _oExpedienteService.ExpedienteGets();
        }

        //GET: api/<ExpedienteController>/5
        [HttpGet("{IdExpediente}", Name = "ExpedienteGet")]
        public Expediente ExpedienteGet(int IdExpediente)
        {
            return _oExpedienteService.ExpedienteGet(IdExpediente);
        }

        //POST: api/<ExpedienteController>
        [HttpPost]
        public void Post([FromBody] Expediente oExpediente)
        {
            if (ModelState.IsValid) _oExpedienteService.ExpedienteAdd(oExpediente);
        }

        //PUT: api/<ExpedienteController>/5
        [HttpPut]
        public void Put([FromBody]Expediente oExpediente)
        {
            if (ModelState.IsValid) _oExpedienteService.ExpedienteUpdate(oExpediente);
        }

        //DELETE: api/<ExpedienteController>/5
        [HttpDelete("{IdExpediente}")]
        public void ExpedienteDelete(int IdExpediente)
        {
            if (IdExpediente != 0) _oExpedienteService.ExpedienteDelete(IdExpediente);
        }
    }
}
