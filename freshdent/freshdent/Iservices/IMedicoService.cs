using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservices
{
    public interface IMedicoService
    {
        Medico MedicoAdd(Medico oMedico);
        List<Medico> MedicoGets();
        Medico MedicoGet(int MedicoId);
        string MedicoDelete(int MedicoId);
        Medico MedicoUpdate(Medico oMedico);
    }
}
