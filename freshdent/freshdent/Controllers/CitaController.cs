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
    public class CitaController : ControllerBase
    {
        private ICitaService _oCitaService;
        public CitaController(ICitaService oCitaService)
        {
            _oCitaService = oCitaService;
        }
        //GET: api/<CitaController>
        [HttpGet]
        public IEnumerable<Cita> CitaGet()
        {
            return _oCitaService.CitaGets();
        }

        //GET: api/<CitaController>/5
        [HttpGet("{IdCita}", Name = "CitaGet")]
        public Cita CitaGet(int IdCita)
        {
            return _oCitaService.CitaGet(IdCita);
        }

        //POST: api/<CitaController>
        [HttpPost]
        public void Post([FromBody] Cita oCita)
        {
            if (ModelState.IsValid) _oCitaService.CitaAdd(oCita);
        }

        //PUT: api/<CitaController>/5
        [HttpPut]
        public void Put([FromBody] Cita oCita)
        {
            if (ModelState.IsValid) _oCitaService.CitaUpdate(oCita);
        }

        //DELETE api/<CitaController>/5
        [HttpDelete("{IdCita}")]
        public void CitaDelete(int IdCita)
        {
            if (IdCita != 0) _oCitaService.CitaDelete(IdCita);
        }
    }
}
