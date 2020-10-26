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
    public class RecetaMedicaController : ControllerBase
    {
        private IRecetaService _oRecetaService;
        public RecetaMedicaController(IRecetaService oRecetaServicie)
        {
            _oRecetaService = oRecetaServicie;
        }
        // GET: api/<EmpleadosController>
        [HttpGet]
        public IEnumerable<RecetaMedica> Get()
        {
            return _oRecetaService.Gets();
        }
        // GET api/<EmpleadosController>/5
        [HttpGet("{id}", Name = "Get")]
        public RecetaMedica Get(int id)
        {
            return _oRecetaService.Get(id);
        }
        // POST api/<EmpleadosController>

        [HttpPost]
        public void Post([FromBody] RecetaMedica oReceta)
        {
            if (ModelState.IsValid) _oRecetaService.Add(oReceta);
        }
        // PUT api/<EmpleadosController>/5
        [HttpPut]
        public void Put([FromBody] RecetaMedica oReceta)
        {
            if (ModelState.IsValid) _oRecetaService.update(oReceta);
        }
        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oRecetaService.Delete(id);
        }
    }

}