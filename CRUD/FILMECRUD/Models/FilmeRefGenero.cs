//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FILMECRUD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FilmeRefGenero
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FilmeRefGenero()
        {
            this.FilmeDetalhe = new HashSet<FilmeDetalhe>();
        }
    
        public int FilmeRefGeneroID { get; set; }
        public string FilmeRefGeneroName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilmeDetalhe> FilmeDetalhe { get; set; }
    }
}