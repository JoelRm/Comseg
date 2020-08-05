using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos.Clases;
using Entidad;

namespace Negocio
{
    public class ClienteNE
    {
        private static ClienteDA obj = new ClienteDA();

        public List<ClienteCLS> ListarCliente()
        {
            return obj.ListarCliente();
        }

        public int AgregarCliente(ClienteCLS objClienteCls)
        {
            return obj.AgregarCliente(objClienteCls);
        }

        public int CambiarEstado(ClienteCLS objClienteCls)
        {
            return obj.CambiarEstado(objClienteCls);
        }

        public List<ClienteCLS> ListarClientePorFiltro(FiltroCLS objFiltro)
        {
            return obj.ListarClientePorFiltro(objFiltro);
        }

        public int EliminarCliente(ClienteCLS objClienteCls)
        {
            return obj.EliminarCliente(objClienteCls);
        }

        public ClienteCLS ObtenerClientePorId(int idcli)
        {
            return obj.ObtenerClientePorId(idcli);
        }

        public int EditarCliente(ClienteCLS objClienteCls)
        {
            return obj.EditarCliente(objClienteCls);
        }
    }
}
