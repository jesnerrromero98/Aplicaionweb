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
        List<MedExp> MedicoGets();
        Medico MedicoGet(int IdMedico);
        String MedicoDelete(int IdMedico);
        Medico MedicoUpdate(Medico oMedico);
    }
}
