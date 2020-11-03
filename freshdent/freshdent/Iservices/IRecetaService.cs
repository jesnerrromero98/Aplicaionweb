using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservices
{
    public interface IRecetaService
    {
        Receta Add(Receta oReceta);
        List<Receta> Gets();
        Receta Get(int RecetaId);
        string Delete(int RecetaId);
        Receta Update(Receta oReceta);
    }
}
