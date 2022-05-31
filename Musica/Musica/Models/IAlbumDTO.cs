using Musica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musica.Models
{
    interface IAlbumDTO
    {
        IEnumerable<AlbumDTO> getAlbumes();
        AlbumDTO getAlbum(string id);
    }
}
