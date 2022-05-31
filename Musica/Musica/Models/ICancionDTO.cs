using Musica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musica.Models
{
    public interface ICancionDTO
    {
        IEnumerable<CancionDTO> getCanciones();
        CancionDTO getCancion(string id);
    }
}
