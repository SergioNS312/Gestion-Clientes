using NTTDATAEXAMEN.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATAEXAMEN.BL
{
    public interface IUsuarioBL
    {
        bool Insertar(UsuarioBE entity);
        List<UsuarioListBE> Listar(UsuarioBE entity);
        bool Delete(int id);
        UsuarioBE Get(int id);
        bool Update(UsuarioBE entity);
    }
}
