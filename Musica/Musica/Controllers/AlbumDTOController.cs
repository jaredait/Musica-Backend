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
    public class AlbumDTOController : ApiController
    {
        IAlbumDTO _albumDTOModelo;

        public AlbumDTOController()
        {
            _albumDTOModelo = new AlbumDTOModelo();
        }

        // GET: api/AlbumDTO
        public HttpResponseMessage Get()
        {
            IEnumerable<AlbumDTO> listaAlbumesDTO = _albumDTOModelo.getAlbumes();
            if(listaAlbumesDTO == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron albumDTOs");
            }
            return Request.CreateResponse(HttpStatusCode.OK, listaAlbumesDTO);
        }

        // GET: api/AlbumDTO/5
        public HttpResponseMessage Get(string id)
        {
            AlbumDTO albumDTO = _albumDTOModelo.getAlbum(id);
            if (albumDTO == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"El albumDTO con id = {id} no existe");
            }
            return Request.CreateResponse(HttpStatusCode.OK, albumDTO);
        }

        // POST: api/AlbumDTO
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AlbumDTO/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AlbumDTO/5
        public void Delete(int id)
        {
        }
    }
}
