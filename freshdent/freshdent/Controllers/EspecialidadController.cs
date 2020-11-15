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
    public class EspecialidadController : ControllerBase
    {
        private IEspecialidadService _oEspecialidadService;
        public EspecialidadController(IEspecialidadService oEspecialidadService)
        {
            _oEspecialidadService = oEspecialidadService;
        }
        //GET: api/<EspecialidadController>
        [HttpGet]
        public IEnumerable<Especialidad> EspecialidadGet()
        {
            return _oEspecialidadService.EspecialidadGets();
        }

        //GET: api/<ConsultaController>/5
        [HttpGet("{IdEspecialidad}", Name = "EspecialidadGet")]
        public Especialidad EspecialidadGet(int IdEspecialidad)
        {
            return _oEspecialidadService.EspecialidadGet(IdEspecialidad);
        }

        //POST: api/<EspecialidadController>
        [HttpPost]
        public void Post([FromBody] Especialidad oEspecialidad)
        {
            if (ModelState.IsValid) _oEspecialidadService.EspecialidadAdd(oEspecialidad);
        }

        //PUT: api/<EspecialidadController>/5
        [HttpPut]
        public void Put([FromBody] Especialidad oEspecialidad)
        {
            if (ModelState.IsValid) _oEspecialidadService.EspecialidadUpdate(oEspecialidad);
        }

        //DELETE api/<ConsultaController>/5
        [HttpDelete("{IdEspecialidad}")]
        public void EspecialidadDelete(int IdEspecialidad)
        {
            if (IdEspecialidad != 0) _oEspecialidadService.EspecialidadDelete(IdEspecialidad);
        }
    }
}
