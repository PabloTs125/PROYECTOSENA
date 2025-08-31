using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Reportes
    {
        private CD_Reportes objeCapadatos = new CD_Reportes();

        public List<Reportes> Ventas(string fechainicio, string fechafin, string idtransaccion) {
            return objeCapadatos.Ventas(fechafin,fechainicio,idtransaccion);
        }

        public DashBoard VERDashBoard()
        {
            return objeCapadatos.verDashBoard();
        }

    }
}
