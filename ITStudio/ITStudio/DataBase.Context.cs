﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITStudio
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ITStudioEntities : DbContext
    {
        public ITStudioEntities()
            : base("name=ITStudioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admins> admins { get; set; }
        public virtual DbSet<applications> applications { get; set; }
        public virtual DbSet<members> members { get; set; }
        public virtual DbSet<notices> notices { get; set; }
        public virtual DbSet<workmap> workmap { get; set; }
        public virtual DbSet<works> works { get; set; }
    }
}
