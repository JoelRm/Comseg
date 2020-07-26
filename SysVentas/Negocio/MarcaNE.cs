using System.Collections.Generic;
using Datos.Clases;
using Entidad;

namespace Negocio
{
    public class MarcaNE
    {
        private static MarcaDA obj = new MarcaDA();


        public List<MarcaCLS> ListarMarcas()
        {
            return obj.ListarMarcas();
        }


        public int AgregarMarca(MarcaCLS objMarcaCls)
        {
            return obj.AgregarMarca(objMarcaCls);
        }


        public int CambiarEstadoMarca(MarcaCLS objMarcaCls)
        {
            return obj.CambiarEstadoMarca(objMarcaCls);
        }


        public List<MarcaCLS> ListarMarcaPorFiltro(FiltroCLS objFiltro)
        {
            return obj.ListarMarcaPorFiltro(objFiltro);
        }


        public int EliminarMarca(MarcaCLS objMarcaCls)
        {
            return obj.EliminarMarca(objMarcaCls);
        }


        public MarcaCLS ObtenerMarcaPorId(int IdMarca)
        {
            return obj.ObtenerMarcaPorId(IdMarca);
        }



        public int EditarMarca(MarcaCLS objMarcaCls)
        {
            return obj.EditarMarca(objMarcaCls);
        }



    }
}
