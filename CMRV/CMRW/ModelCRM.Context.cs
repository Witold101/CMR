﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class crm_dbEntities : DbContext
    {
        public crm_dbEntities()
            : base("name=crm_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<td_department> td_department { get; set; }
        public virtual DbSet<td_employee> td_employee { get; set; }
        public virtual DbSet<td_level> td_level { get; set; }
        public virtual DbSet<td_client> td_client { get; set; }
        public virtual DbSet<td_contact> td_contact { get; set; }
        public virtual DbSet<td_country> td_country { get; set; }
        public virtual DbSet<td_maill> td_maill { get; set; }
        public virtual DbSet<td_note> td_note { get; set; }
        public virtual DbSet<td_phone> td_phone { get; set; }
    }
}
