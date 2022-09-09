using SanDiegoBE;
using SanDiegoBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SanDiegoApi.Controllers
{
    public class LecturaContadorController : ApiController
    {
        [HttpGet]
        [Route("api/LecturaContador")]
        public IEnumerable<LecturaContadorBE> Get()
        {
            try
            {
                var vBll = new LecturaContadorBLL();
                return vBll.Listar(new LecturaContadorBE());
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [HttpPost]
        [Route("api/LecturaContador/Listar")]
        public IEnumerable<LecturaContadorBE> Get([FromBody]LecturaContadorBE entidad)
        {
            try
            {
                if (entidad == null)
                    entidad = new LecturaContadorBE();

                    var vBll = new LecturaContadorBLL();
                return vBll.Listar(entidad);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }


        // POST: api/LecturaContador
        //Crear
        [HttpPost]
        [Route("api/LecturaContador/Add")]
        public IHttpActionResult Add([FromBody]LecturaContadorBE entidad)
        {
            try
            {
                var vBll = new LecturaContadorBLL();
                vBll.Crear(entidad);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        // PUT: api/LecturaContador/5
        //Actualizar
        [HttpPut]
        [Route("api/LecturaContador/Update")]
        public IHttpActionResult Update([FromBody]LecturaContadorBE entidad)
        {
            try
            {
                var vBll = new LecturaContadorBLL();
                vBll.Actualizar(entidad);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        // DELETE: api/LecturaContador/5
        //Borrar
        [HttpDelete]
        [Route("api/LecturaContador/Delete")]
        public IHttpActionResult Delete([FromBody]LecturaContadorBE entidad)
        {
            try
            {
                var vBll = new LecturaContadorBLL();
                vBll.Eliminar(entidad);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }
    }
}
