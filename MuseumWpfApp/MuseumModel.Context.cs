//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MuseumWpfApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class museumEntities : DbContext
    {
        public museumEntities()
            : base("name=museumEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Exhibition> Exhibitions { get; set; }
        public virtual DbSet<InnerAction> InnerActions { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<OuterAction> OuterActions { get; set; }
        public virtual DbSet<Set> Sets { get; set; }
    }
}
