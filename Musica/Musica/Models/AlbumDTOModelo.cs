using Musica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musica.Models
{
    public class AlbumDTOModelo : IAlbumDTO
    {
        MusicaEntities _contexto;

        public AlbumDTOModelo()
        {
            _contexto = new MusicaEntities();
            _contexto.Configuration.ProxyCreationEnabled = false;
        }

        public AlbumDTO getAlbum(string id)
        {
            ALBUM album = _contexto.ALBUM.FirstOrDefault(a => a.ALB_ID == id);
            ARTISTA artista = _contexto.ARTISTA.FirstOrDefault(a => a.ART_ID == album.ART_ID);
            AlbumDTO albumDTO = new AlbumDTO()
            {
                ALB_ID = album.ALB_ID,
                ALB_NOMBRE = album.ALB_NOMBRE,
                ALB_FECHA_LANZAMIENTO = album.ALB_FECHA_LANZAMIENTO,
                ART_ID = album.ART_ID,
                ART_NOMBRE = artista.ART_NOMBRE
            };
            return albumDTO;
        }

        public IEnumerable<AlbumDTO> getAlbumes()
        {
            List<ALBUM> listaAlbumes = _contexto.ALBUM.ToList();
            List<ARTISTA> listaArtistas = _contexto.ARTISTA.ToList();

            List<AlbumDTO> listaAlbumDTOs = new List<AlbumDTO>();

            foreach(ALBUM album in listaAlbumes)
            {
                ARTISTA artista = listaArtistas.FirstOrDefault(a => a.ART_ID == album.ART_ID);
                AlbumDTO albumDTOTemp = new AlbumDTO()
                {
                    ALB_ID = album.ALB_ID,
                    ALB_NOMBRE = album.ALB_NOMBRE,
                    ALB_FECHA_LANZAMIENTO = album.ALB_FECHA_LANZAMIENTO,
                    ART_ID = album.ART_ID,
                    ART_NOMBRE = artista.ART_NOMBRE
                };
                listaAlbumDTOs.Add(albumDTOTemp);
            }
            return listaAlbumDTOs;
        }
    }
}