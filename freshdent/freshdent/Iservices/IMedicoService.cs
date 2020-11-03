using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservices
{
    public interface IMedicoService
    {
        Medico Add(Medico oMedico);
        List<Medico> Gets();
        Medico Get(int MedicoId);
        string Delete(int MedicoId);
        Medico Update(Medico oMedico);
    }
}
