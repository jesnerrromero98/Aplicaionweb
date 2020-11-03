using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservices
{
    public interface IExpedienteService
    {
        Expediente Add(Expediente oExpediente);
        List<Expediente> Gets();
        Expediente Get(int ExpedienteId);
        string Delete(int ExpedienteId);
        Expediente Update(Expediente oExpediente);
    }
}
