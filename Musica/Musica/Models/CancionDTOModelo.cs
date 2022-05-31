using Musica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musica.Models
{
    public class CancionDTOModelo : ICancionDTO
    {
        MusicaEntities _contexto;

        public CancionDTOModelo()
        {
            _contexto = new MusicaEntities();
            _contexto.Configuration.ProxyCreationEnabled = false;
        }

        public CancionDTO getCancion(string id)
        {
            try
            {
                CANCION cancion = _contexto.CANCION.FirstOrDefault(c => c.CAN_ID == id);
                ALBUM album = _contexto.ALBUM.FirstOrDefault(a => a.ALB_ID == cancion.ALB_ID);
                GENERO genero = _contexto.GENERO.FirstOrDefault(g => g.GEN_ID == cancion.GEN_ID);

                CancionDTO cancionDTO = new CancionDTO()
                {
                    CAN_ID = cancion.CAN_ID,
                    ALB_ID = cancion.ALB_ID,
                    GEN_ID = cancion.GEN_ID,
                    CAN_NOMBRE = cancion.CAN_NOMBRE,
                    CAN_DURACION = cancion.CAN_DURACION,
                    ALB_NOMBRE = album.ALB_NOMBRE,
                    GEN_NOMBRE = genero.GEN_NOMBRE
                };
                return cancionDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<CancionDTO> getCanciones()
        {
            List<CANCION> listaCanciones = _contexto.CANCION.ToList();
            List<ALBUM> listaAlbumes = _contexto.ALBUM.ToList();
            List<GENERO> listaGeneros = _contexto.GENERO.ToList();
            List<CancionDTO> listaCancionDTOs = new List<CancionDTO>();

            foreach(CANCION cancion in listaCanciones)
            {
                ALBUM album = listaAlbumes.FirstOrDefault(a => a.ALB_ID == cancion.ALB_ID);
                GENERO genero = listaGeneros.FirstOrDefault(g => g.GEN_ID == cancion.GEN_ID);

                CancionDTO cancionDTOTemp = new CancionDTO()
                {
                    CAN_ID = cancion.CAN_ID,
                    ALB_ID = cancion.ALB_ID,
                    GEN_ID = cancion.GEN_ID,
                    CAN_NOMBRE = cancion.CAN_NOMBRE,
                    CAN_DURACION = cancion.CAN_DURACION,
                    ALB_NOMBRE = album.ALB_NOMBRE,
                    GEN_NOMBRE = genero.GEN_NOMBRE
                };
                listaCancionDTOs.Add(cancionDTOTemp);
            }
            return listaCancionDTOs;
        }
    }
}