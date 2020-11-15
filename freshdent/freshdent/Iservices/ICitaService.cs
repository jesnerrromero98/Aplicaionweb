using freshdent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Iservices
{
    public interface ICitaService
    {
        Cita CitaAdd(Cita oCita);
        List<Cita> CitaGets();
        Cita CitaGet(int IdCita);
        String CitaDelete(int IdCita);
        Cita CitaUpdate(Cita oCita);
    }
}
