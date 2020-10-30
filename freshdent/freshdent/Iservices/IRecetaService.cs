using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservices
{
    public interface IRecetaService
    {
        IRecetaService Add(IRecetaService oReceta);
        List<IRecetaService> Gets();
        IRecetaService Get(int RecetaId);
        string Delete(int RecetaId);
        IRecetaService Update(IRecetaService oReceta);
    }
}
