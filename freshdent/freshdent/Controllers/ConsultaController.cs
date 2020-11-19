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
        public IEnumerable<ConsMedExp> ConsultaGet()
        {
            return _oConsultaService.ConsultaGets();
        }

        //GET: api/<ConsultaController>/5
        [HttpGet("{IdConsulta}", Name = "ConsultaGet")]
        public Consulta ConsultaGet(int IdConsulta)
        {
            return _oConsultaService.ConsultaGet(IdConsulta);
        }

        //POST: api/<ConsultaController>
        [HttpPost]
        public void Post([FromBody] Consulta oConsulta)
        {
            if (ModelState.IsValid) _oConsultaService.ConsultaAdd(oConsulta);
        }

        //PUT: api/<ConsultaController>/5
        [HttpPut]
        public void Put([FromBody] Consulta oConsulta)
        {
            if (ModelState.IsValid) _oConsultaService.ConsultaUpdate(oConsulta);
        }

        //DELETE api/<ConsultaController>/5
        [HttpDelete("{IdConsulta}")]
        public void ConsultaDelete(int IdConsulta)
        {
            if (IdConsulta != 0) _oConsultaService.ConsultaDelete(IdConsulta);
        }
    }
}
