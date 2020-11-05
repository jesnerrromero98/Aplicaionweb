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
        public IEnumerable<Consulta> ConsultaGets()
        {
            return _oConsultaService.ConsultaGets();
        }

        //GET: api/<ConsultaController>/5
        [HttpGet("{Id}", Name = "ConsultaGet")]
        public Consulta ConsultaGet(int id)
        {
            return _oConsultaService.ConsultaGet(id);
        }

        //POST: api/<ConsultaController>
        [HttpPost]
        public void Post([FromBody] Consulta oConsulta)
        {
            if (ModelState.IsValid) _oConsultaService.ConsultaAdd(oConsulta);
        }

        //PUT: api/<MedicoController>/5
        [HttpPut]
        public void Put([FromBody] Consulta oConsulta)
        {
            if (ModelState.IsValid) _oConsultaService.ConsultaUpdate(oConsulta);
        }

        //DELETE api/<ConsultaController>/5
        [HttpDelete("{Id}")]
        public void Delete(int id)
        {
            if (id != 0) _oConsultaService.ConsultaDelete(id);
        }
    }
}
