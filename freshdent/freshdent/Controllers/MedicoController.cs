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
    public class MedicoController : ControllerBase
    {
        private IMedicoSevice _oMedicoService;
        public MedicoController(IMedicoSevice oMedicoService)
        {
            _oMedicoService = oMedicoService;
        }
        // GET: api/<EmpleadosController>
        [HttpGet]
        public IEnumerable<Medico> Get()
        {
            return _oMedicoService.Gets();
        }
        // GET api/<EmpleadosController>/5
        [HttpGet("{id}", Name = "Get")]
        public Medico Get(int id)
        {
            return _oMedicoService.Get(id);
        }
        // POST api/<EmpleadosController>

        [HttpPost]
        public void Post([FromBody] Medico oMedico)
        {
            if (ModelState.IsValid) _oMedicoService.Add(oMedico);
        }
        // PUT api/<EmpleadosController>/5
        [HttpPut]
        public void Put([FromBody] Medico oMedico)
        {
            if (ModelState.IsValid) _oMedicoService.update(oMedico);
        }
        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oMedicoService.Delete(id);
        }
    }

}