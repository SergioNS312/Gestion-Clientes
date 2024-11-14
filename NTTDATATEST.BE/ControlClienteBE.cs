using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATAEXAMEN.BE
{
    public class ControlClienteBE
    {
        public int id { set; get; }
        public string empresa { set; get; }
        public string nro_doi { set; get; }
        public string tipo_contrato { set; get; }
        public string tipo_software { set; get; }
        public int nro_empresas { set; get; }
        public int? nro_empresas_con_data { set; get; }
        public int tipo_pago { set; get; }
        public decimal? deuda_anterior { set; get; }
        public decimal? descuento { set; get; }
        public decimal? licencia_anual { set; get; }
        public decimal? total_a_pagar { set; get; }
        public string contacto_nombre { set; get; }
        public string contcto_telefono { set; get; }
        public string compromiso_descripcion { set; get; }
        public DateTime? compromiso_fecha { set; get; }
        public decimal? compromiso_importe { set; get; }
        public string observacion { set; get; }
        public int? estado { set; get; }
        public DateTime? fecha_vencimiento { set; get; }
        public int? limite_empresas { set; get; }
        public int? limite_usuarios { set; get; }
    }
}
