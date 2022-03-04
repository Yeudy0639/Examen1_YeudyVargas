using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ParametrosEntity : EN
    {
        public int? Id_Parametro { get; set; }

        public string Descripcion { get; set; }
        public object Codigo { get; set; }
        public object Valor { get; set; }
    }
}
