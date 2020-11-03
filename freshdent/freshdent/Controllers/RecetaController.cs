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
    public class RecetaController : ControllerBase
    {
        private IRecetaService _oRecetaService;

        public RecetaController(IRecetaService oRecetaService)
        {
            _oRecetaService = oRecetaService;
        }

        //GET: api/<RecetaController>
        [HttpGet]
        public IEnumerable<Receta> Get()
        {
            return _oRecetaService.Gets();
        }

        //GET: api/<RecetaController>/5
        [HttpGet("{IdReceta}", Name ="Get")]
        public Receta Get (int id)
        {
            return _oRecetaService.Get(id);
        }

        //POST: api/<RecetaController>
        [HttpPost]
        public void Post([FromBody] Receta oReceta)
        {
            if (ModelState.IsValid) _oRecetaService.Add(oReceta);
        }
        //PUT: api/<MedicoController>/5
        [HttpPut]
        public void Put([FromBody]Receta oReceta)
        {
            if (ModelState.IsValid) _oRecetaService.Update(oReceta);
        }

        //DELETE api/<RecetaController>/5
        [HttpDelete("{IdReceta}")]
        public void Delete (int id)
        {
            if (id != 0) _oRecetaService.Delete(id);
        }
    }
}
