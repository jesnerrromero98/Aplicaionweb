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
        IExpedienteService Add(IExpedienteService oExpediente);
        List<IExpedienteService> Gets();
        IExpedienteService Get(int ExpedienteId);
        string Delete(int ExpedienteId);
        IExpedienteService Update(IExpedienteService oExpediente);
    }
}
