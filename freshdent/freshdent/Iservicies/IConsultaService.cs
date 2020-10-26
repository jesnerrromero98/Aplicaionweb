using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservicies
{
    public interface IConsultaService
    {
        Consulta Add(Consulta oConsulta);
        List<Consulta> Gets();
        Consulta Get(int IdConsulta);
        string Delete(int IdConsulta);
        Consulta update(Consulta oConsulta);
    }
}
