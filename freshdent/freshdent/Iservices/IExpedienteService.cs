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
        Expediente ExpedienteAdd(Expediente oExpediente);
        List<Expediente> ExpedienteGets();
        Expediente ExpedienteGet(int ExpedienteId);
        string ExpedienteDelete(int ExpedienteId);
        Expediente ExpedienteUpdate(Expediente oExpediente);
    }
}
