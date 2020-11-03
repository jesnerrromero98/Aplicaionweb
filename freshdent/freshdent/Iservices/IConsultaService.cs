using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservices
{
    public interface IConsultaService
    {
        Consulta Add(Consulta oConsulta);
        List<Consulta> Gets();
        Consulta Get(int ConsultaId);
        string Delete(int ConsultaId);
        Consulta Update(Consulta oConsulta);
    }
}
