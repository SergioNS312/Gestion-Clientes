using NTTDATAEXAMEN.BE;
using NTTDATAEXAMEN.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATAEXAMEN.BL
{
    public class ControlClienteBL : IControlClienteBL
    {
        private readonly IControlClienteDAC _controlClienteDAC;

        public ControlClienteBL()
        {
            _controlClienteDAC = new ControlClienteDAC();
        }

        public List<ControlClienteBE> ListarControlCliente()
        {
            return _controlClienteDAC.ListarControlCliente();
        }
    }
}
