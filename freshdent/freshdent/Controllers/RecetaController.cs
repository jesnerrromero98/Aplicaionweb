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
        public IEnumerable<Receta> RecetaGet()
        {
            return _oRecetaService.RecetaGets();
        }

        //GET: api/<RecetaController>/5
        [HttpGet("{Id}", Name ="RecetaGet")]
        public Receta RecetaGet (int id)
        {
            return _oRecetaService.RecetaGet(id);
        }

        //POST: api/<RecetaController>
        [HttpPost]
        public void Post([FromBody] Receta oReceta)
        {
            if (ModelState.IsValid) _oRecetaService.RecetaAdd(oReceta);
        }

        //PUT: api/<MedicoController>/5
        [HttpPut]
        public void Put([FromBody]Receta oReceta)
        {
            if (ModelState.IsValid) _oRecetaService.RecetaUpdate(oReceta);
        }

        //DELETE api/<RecetaController>/5
        [HttpDelete("{Id}")]
        public void RecetaDelete (int id)
        {
            if (id != 0) _oRecetaService.RecetaDelete(id);
        }
    }
}
