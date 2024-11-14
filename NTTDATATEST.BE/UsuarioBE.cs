using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATAEXAMEN.BE
{
    public class UsuarioBE
    {
        public int id { set; get; }
        public string codigo { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
        public int edad { set; get; }
        public string correo { set; get; }
        public int idGenero { set; get; }
        public int idNacionalidad { set; get; }
        public int idPerfil { set; get; }

    }
}
