//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Musica
{
    using System;
    using System.Collections.Generic;
    
    public partial class ALBUM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALBUM()
        {
            this.CANCION = new HashSet<CANCION>();
        }
    
        public string ALB_ID { get; set; }
        public string ART_ID { get; set; }
        public string ALB_NOMBRE { get; set; }
        public Nullable<System.DateTime> ALB_FECHA_LANZAMIENTO { get; set; }
    
        public virtual ARTISTA ARTISTA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CANCION> CANCION { get; set; }
    }
}