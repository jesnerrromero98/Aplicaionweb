using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservices
{
    public interface IConsultaService
    {
        Consulta ConsultaAdd(Consulta oConsulta);
        List<Consulta> ConsultaGets();
        Consulta ConsultaGet(int IdConsulta);
        String ConsultaDelete(int IdConsulta);
        Consulta ConsultaUpdate(Consulta oConsulta);
    }
}
