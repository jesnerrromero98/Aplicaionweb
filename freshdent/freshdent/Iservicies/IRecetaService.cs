using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservicies
{
    public interface IRecetaService
    {
        RecetaMedica Add(RecetaMedica oRecetaMedica);
        List<RecetaMedica> Gets();
        RecetaMedica Get(int RecetaMedicaId);
        string Delete(int RecetaMedicaId);
        RecetaMedica update(RecetaMedica oRecetaMedica);
    }
}
