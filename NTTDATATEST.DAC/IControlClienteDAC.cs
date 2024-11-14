using NTTDATAEXAMEN.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATAEXAMEN.DAC
{
    public interface IControlClienteDAC
    {
        List<ControlClienteBE> ListarControlCliente();
    }
}
