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
    
    public partial class td_note
    {
        public int id { get; set; }
        public string note { get; set; }
        public System.DateTime create_date { get; set; }
        public int client_id { get; set; }
    
        public virtual td_client td_client { get; set; }
    }
}