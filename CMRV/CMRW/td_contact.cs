//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMRW
{
    using System;
    using System.Collections.Generic;
    
    public partial class td_contact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public td_contact()
        {
            this.td_maill = new HashSet<td_maill>();
            this.td_phone = new HashSet<td_phone>();
        }
    
        public int id { get; set; }
        public System.DateTime create_date { get; set; }
        public string name { get; set; }
        public int client_id { get; set; }
        public string department { get; set; }
        public string note { get; set; }
    
        public virtual td_client td_client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<td_maill> td_maill { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<td_phone> td_phone { get; set; }
    }
}