using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Models
{
    public class Receta
    {
        public int IdReceta { get; set; }
        public string Nombre { get; set; }
        public string Presentacion { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public string Error { get; set; }
    }
}
