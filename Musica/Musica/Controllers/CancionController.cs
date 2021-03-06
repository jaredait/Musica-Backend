using Musica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Musica.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CancionController : ApiController
    {
        ICancion _cancionModelo;

        public CancionController()
        {
            _cancionModelo = new CancionModelo();
        }

        public HttpResponseMessage Get()
        {
            IEnumerable<CANCION> listaCanciones = _cancionModelo.getCanciones();
            if(listaCanciones == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron canciones");
            }
            return Request.CreateResponse(HttpStatusCode.OK, listaCanciones);
        }

        public HttpResponseMessage Get(string id)
        {
            CANCION cancionTemp = _cancionModelo.getCancion(id);
            if (cancionTemp == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"La canción con id = {id} no existe");
            }
            return Request.CreateResponse(HttpStatusCode.OK, cancionTemp);
        }

        public HttpResponseMessage Post([FromBody] CANCION nuevaCancion)
        {
            try
            {
                _cancionModelo.addCancion(nuevaCancion);

                var mensaje = Request.CreateResponse(HttpStatusCode.Created, nuevaCancion);
                mensaje.Headers.Location = new Uri(Request.RequestUri + nuevaCancion.CAN_ID.ToString());

                return mensaje;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage Put([FromBody] CANCION cancionActualizada)
        {
            try
            {
                CANCION cancionTemp = _cancionModelo.updateCancion(cancionActualizada.CAN_ID, cancionActualizada);

                if (cancionTemp == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"La canción con id = {cancionActualizada.CAN_ID} no existe");
                }
                return Request.CreateResponse(HttpStatusCode.OK, cancionTemp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(string id)
        {
            try
            {
                bool operacionExitosa = _cancionModelo.removeCancion(id);
                if (!operacionExitosa)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"La canción con id = {id} no existe");
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}