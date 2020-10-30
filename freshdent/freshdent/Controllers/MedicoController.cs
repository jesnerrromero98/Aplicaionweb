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
    public class MedicoController : ControllerBase
    {
        private IMedicoService _oMedicoService;
        public MedicoController(IMedicoService oMedicoService)
        {
            _oMedicoService = oMedicoService;
        }
        //GET: api/<RecetaController>
        [HttpGet]
        public IEnumerable<Medico> Get()
        {
            return _oMedicoService.Gets();
        }

        //GET: api/<MedicoController>/5
        [HttpGet("{@id}", Name = "Get")]
        public Medico Get(int id)
        {
            return _oMedicoService.Get(id);
        }

        //POST: api/<MedicoController>
        [HttpPost]
        public void Post([FromBody] Medico oMedico)
        {
            if (ModelState.IsValid) _oMedicoService.Add(oMedico);
        }

        //DELETE api/<MedicoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oMedicoService.Delete(id);
        }
    }
}
