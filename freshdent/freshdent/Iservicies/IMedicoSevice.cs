using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservicies
{
   public interface IMedicoSevice
   {
        Medico Add(Medico oMedico);
        List<Medico> Gets();
        Medico Get(int IdMedico);
        string Delete(int  IdMedico);
        Medico update(Medico oMedico);
    }
}
