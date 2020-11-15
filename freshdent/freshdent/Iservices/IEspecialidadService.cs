using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservices
{
    public interface IEspecialidadService
    {
        Especialidad EspecialidadAdd(Especialidad oEspecialidad);
        List<Especialidad> EspecialidadGets();
        Especialidad EspecialidadGet(int IdEspecialidad);
        String EspecialidadDelete(int IdEspecialidad);
        Especialidad EspecialidadUpdate(Especialidad oEspecialidad);
    }
}
