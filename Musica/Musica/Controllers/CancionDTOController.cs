using Musica.DTO;
using Musica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Musica.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CancionDTOController : ApiController
    {
        ICancionDTO _cancionDTOModelo;

        public CancionDTOController()
        {
            _cancionDTOModelo = new CancionDTOModelo();
        }

        // GET: api/CancionDTO
        public HttpResponseMessage Get()
        {
            IEnumerable<CancionDTO> listaCancionDTOs = _cancionDTOModelo.getCanciones();
            if (listaCancionDTOs == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron cancionDTOs");
            }
            return Request.CreateResponse(HttpStatusCode.OK, listaCancionDTOs);
        }

        // GET: api/CancionDTO/5
        public HttpResponseMessage Get(string id)
        {
            CancionDTO cancionDTO = _cancionDTOModelo.getCancion(id);
            if (cancionDTO == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"La canciónDTO con id = {id} no existe");
            }
            return Request.CreateResponse(HttpStatusCode.OK, cancionDTO);
        }

        // POST: api/CancionDTO
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CancionDTO/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CancionDTO/5
        public void Delete(int id)
        {
        }
    }
}
