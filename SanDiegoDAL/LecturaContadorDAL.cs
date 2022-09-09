using SanDiegoBE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanDiegoDAL
{
    public class LecturaContadorDAL
    {
        public int Crear(LecturaContadorBE e)
        {
            using (DataModelDataContext DC = new DataModelDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                return (int)DC.LecturaContador_Crear(
                    e.NumContador,
                    e.Fecha,
                    e.Valor,
                    e.Observaciones
                );
            }
        }

        public int Actualizar(LecturaContadorBE e)
        {
            using (DataModelDataContext DC = new DataModelDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                return (int)DC.LecturaContador_Actualizar(
                    e.IdLectura,
                    e.NumContador,
                    e.Fecha,
                    e.Valor,
                    e.Observaciones
                );
            }
        }

        public bool Eliminar(LecturaContadorBE e)
        {
            using (DataModelDataContext DC = new DataModelDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                DC.LecturaContador_Eliminar(
                e.IdLectura
                );

                return true;
            }
        }

        public IList<LecturaContadorBE> Listar(LecturaContadorBE e)
        {
            using (DataModelDataContext DC = new DataModelDataContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                return new List<LecturaContadorBE>(DC.LecturaContador_Listar(e.IdLectura));
            }
        }
    }
}
