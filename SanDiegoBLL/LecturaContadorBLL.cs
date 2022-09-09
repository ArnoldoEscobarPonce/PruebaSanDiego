using SanDiegoBE;
using SanDiegoDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanDiegoBLL
{
    public class LecturaContadorBLL
    {
        public IList<LecturaContadorBE> Listar(LecturaContadorBE entidad)
        {
            try
            {
                LecturaContadorDAL _dal = new LecturaContadorDAL();
                return _dal.Listar(entidad);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Crear(LecturaContadorBE entidad)
        {
            try
            {
                ValidarDatos(entidad, "Crear");
                LecturaContadorDAL _dal = new LecturaContadorDAL();
                return _dal.Crear(entidad);
            }
            catch (Exception ex)
            {
                throw new Exception("LecturaContador(Crear): " + ex.Message);
            }
        }

        public int Actualizar(LecturaContadorBE entidad)
        {
            try
            {
                ValidarDatos(entidad, "Actualizar");
                LecturaContadorDAL _dal = new LecturaContadorDAL();
                return _dal.Actualizar(entidad);
            }
            catch (Exception ex)
            {
                throw new Exception("LecturaContador(Actualizar): " + ex.Message);
            }
        }

        public bool Eliminar(LecturaContadorBE entidad)
        {
            try
            {
                ValidarDatos(entidad, "Eliminar");
                LecturaContadorDAL _dal = new LecturaContadorDAL();
                return _dal.Eliminar(entidad);
            }
            catch (Exception ex)
            {
                throw new Exception("LecturaContador(Eliminar): " + ex.Message);
            }
        }

        public bool ValidarDatos(LecturaContadorBE entidad, string operacion)
        {
            switch (operacion)
            {
                case "Crear":
                    Valida_NumContador(entidad);
                    Valida_Fecha(entidad);
                    Valida_Valor(entidad);
                    Valida_Observaciones(entidad);
                    break;
                case "Actualizar":
                    Valida_IdLectura(entidad);
                    Valida_NumContador(entidad);
                    Valida_Fecha(entidad);
                    Valida_Valor(entidad);
                    Valida_Observaciones(entidad);
                    break;
                case "Eliminar":
                    Valida_IdLectura(entidad);
                    break;
                case "Listar":
                    break;
            }
            return true;
        }

        private void Valida_IdLectura(LecturaContadorBE entidad)
        {
            if (entidad.IdLectura == null)
                throw new Exception("El IdLectura no puede ser nulo");
        }

        private void Valida_NumContador(LecturaContadorBE entidad)
        {
            if (String.IsNullOrEmpty(entidad.NumContador))
                throw new Exception("El NumContador no puede ser nulo");
        }

        private void Valida_Fecha(LecturaContadorBE entidad)
        {
            if (entidad.Fecha == null)
                throw new Exception("La Fecha no puede ser nula");
        }

        private void Valida_Valor(LecturaContadorBE entidad)
        {
            if (entidad.Valor == null)
                throw new Exception("El Valor no puede ser nulo");
        }

        private void Valida_Observaciones(LecturaContadorBE entidad)
        {
            if (String.IsNullOrEmpty(entidad.Observaciones))
                throw new Exception("Las Observaciones no puede ser nulas");
        }

        private void Valida_Estado(LecturaContadorBE entidad)
        {
            if (String.IsNullOrEmpty(entidad.Estado))
                throw new Exception("El Estado no puede ser nulo");
        }
    }
}
