using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservices
{
    public interface IRecetaService
    {
        Receta RecetaAdd(Receta oReceta);
        List<Receta> RecetaGets();
        Receta RecetaGet(int IdReceta);
        String RecetaDelete(int IdReceta);
        Receta RecetaUpdate(Receta oReceta);
    }
}
