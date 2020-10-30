using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservices
{
    public interface IConsultaService
    {
        IConsultaService Add(IConsultaService oConsulta);
        List<IConsultaService> Gets();
        IConsultaService Get(int ConsultaId);
        string Delete(int ConsultaId);
        IConsultaService Update(IConsultaService oConsulta);
    }
}
