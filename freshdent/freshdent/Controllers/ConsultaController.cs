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
    public class ConsultaController : ControllerBase
    {
        private IConsultaService _oConsultaService;
        public ConsultaController(IConsultaService oConsultaService)
        {
            _oConsultaService = oConsultaService;
        }
        //GET: api/<ConsultaController>
        [HttpGet]
        public IEnumerable<Consulta> Get()
        {
            return _oConsultaService.Gets();
        }

        //GET: api/<ConsultaController>/5
        [HttpGet("{@id}", Name = "Get")]
        public Medico Get(int id)
        {
            return _oConsultaService.Get(id);
        }

        //POST: api/<ConsultaController>
        [HttpPost]
        public void Post([FromBody] Consulta oConsulta)
        {
            if (ModelState.IsValid) _oConsultaService.Add(oConsulta);
        }

        //DELETE api/<ConsultaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oConsultaService.Delete(id);
        }
    }
}
