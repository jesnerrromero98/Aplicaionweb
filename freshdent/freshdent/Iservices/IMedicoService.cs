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
        Medico MedicoGet(int IdMedico);
        string MedicoDelete(int IdMedico);
        Medico MedicoUpdate(Medico oMedico);
    }
}
