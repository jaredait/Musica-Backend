using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musica.DTO
{
    public class CancionDTO
    {
        public string CAN_ID { get; set; }
        public string ALB_ID { get; set; }
        public string GEN_ID { get; set; }
        public string CAN_NOMBRE { get; set; }
        public Nullable<decimal> CAN_DURACION { get; set; }

        public string ALB_NOMBRE { get; set; }
        public string GEN_NOMBRE { get; set; }
    }
}