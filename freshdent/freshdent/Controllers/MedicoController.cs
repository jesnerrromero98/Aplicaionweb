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
        public IEnumerable<Medico> MedicoGet()
        {
            return _oMedicoService.MedicoGets();
        }

        //GET: api/<MedicoController>/5
        [HttpGet("{Id}", Name = "MedicoGet")]
        public Medico MedicoGet(int id)
        {
            return _oMedicoService.MedicoGet(id);
        }

        //POST: api/<MedicoController>
        [HttpPost]
        public void Post([FromBody] Medico oMedico)
        {
            if (ModelState.IsValid) _oMedicoService.MedicoAdd(oMedico);
        }

        //PUT: api/<MedicoController>/5
        [HttpPut]
        public void Put ([FromBody] Medico oMedico)
        {
            if (ModelState.IsValid) _oMedicoService.MedicoUpdate(oMedico);
        }

        //DELETE api/<MedicoController>/5
        [HttpDelete("{Id}")]
        public void Delete(int id)
        {
            if (id != 0) _oMedicoService.MedicoDelete(id);
        }
    }
}
