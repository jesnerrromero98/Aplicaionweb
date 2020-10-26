using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservicies
{
   public interface IExpedienteServicie
   {
        Expediente Add(Expediente oExpediente);
        List<Expediente> Gets();
        Expediente Get(int ExpedienteId);
        string Delete(int Cedula);
        Expediente update(Expediente oExpediente);
   }
}
