using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Clases;
using Entidad;

namespace Negocio
{
    public class LineaNE
    {
        private static LineaDA obj = new LineaDA();
        
        public List<LineaCLS> ListarLineas()
        {
            return obj.ListarLineas();
        }

        public int AgregarLinea(LineaCLS objLineaCls)
        {
            return obj.AgregarLinea(objLineaCls);
        }
        public int CambiarEstadoLinea(LineaCLS objLineaCls)
        {
            return obj.CambiarEstadoLinea(objLineaCls);
        }
        public List<LineaCLS> ListarLineasPorFiltro(FiltroCLS objFiltro)
        {
            return obj.ListarLineasPorFiltro(objFiltro);
        }
        public int EliminarLinea(LineaCLS objLineaCls)
        {
            return obj.EliminarLineas(objLineaCls);
        }
        public LineaCLS ObtenerLineaPorId(int IdLinea)
        {
            return obj.ObtenerLineaPorId(IdLinea);
        }
        public int EditarLinea(LineaCLS objLineaCls)
        {
            return obj.EditarLinea(objLineaCls);
        }
    }
}
