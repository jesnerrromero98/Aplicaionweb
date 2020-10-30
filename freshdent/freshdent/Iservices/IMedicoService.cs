using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservices
{
    public interface IMedicoService
    {
        IMedicoService Add(IMedicoService oMedico);
        List<IMedicoService> Gets();
        IMedicoService Get(int MedicoId);
        string Delete(int MedicoId);
        IMedicoService Update(IMedicoService oMedico);
    }
}
