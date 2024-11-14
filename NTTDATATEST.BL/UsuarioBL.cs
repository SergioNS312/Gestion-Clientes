using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTDATAEXAMEN.BE;
using NTTDATAEXAMEN.DAC;

namespace NTTDATAEXAMEN.BL
{
    public class UsuarioBL : IUsuarioBL
    {
        private readonly IUsuarioDAC _usuarioDAC;

        public UsuarioBL()
        {
            _usuarioDAC = new UsuarioDAC();
        }
        public bool Delete(int id)
        {
            return _usuarioDAC.Delete(id);
        }

        public UsuarioBE Get(int id)
        {
            return _usuarioDAC.Get(id);
        }

        public bool Insertar(UsuarioBE entity)
        {
            return _usuarioDAC.Insertar(entity);
        }

        public List<UsuarioListBE> Listar(UsuarioBE entity)
        {
            return _usuarioDAC.Listar(entity);
        }

        public bool Update(UsuarioBE entity)
        {
            return _usuarioDAC.Update(entity);
        }
    }
}
