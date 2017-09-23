﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alpenstern_BackEnd_Neu.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class alpensternEntities2 : DbContext
    {
        public alpensternEntities2()
            : base("name=alpensternEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Anfrage> Anfrage { get; set; }
        public virtual DbSet<Ausstattung> Ausstattung { get; set; }
        public virtual DbSet<Bilder> Bilder { get; set; }
        public virtual DbSet<Dinner> Dinner { get; set; }
        public virtual DbSet<Extras> Extras { get; set; }
        public virtual DbSet<Gaestebuch> Gaestebuch { get; set; }
        public virtual DbSet<Gast> Gast { get; set; }
        public virtual DbSet<Gastlogin> Gastlogin { get; set; }
        public virtual DbSet<Kategorie> Kategorie { get; set; }
        public virtual DbSet<Kategorieanfrage> Kategorieanfrage { get; set; }
        public virtual DbSet<Kategorieausstattung> Kategorieausstattung { get; set; }
        public virtual DbSet<Komplettbuchung> Komplettbuchung { get; set; }
        public virtual DbSet<Komplettpaket> Komplettpaket { get; set; }
        public virtual DbSet<Land> Land { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public virtual DbSet<Rechnung> Rechnung { get; set; }
        public virtual DbSet<Rueckruf> Rueckruf { get; set; }
        public virtual DbSet<Saison> Saison { get; set; }
        public virtual DbSet<Spa> Spa { get; set; }
        public virtual DbSet<Stadt> Stadt { get; set; }
        public virtual DbSet<Zimmer> Zimmer { get; set; }
        public virtual DbSet<Zimmerbuchung> Zimmerbuchung { get; set; }
        public virtual DbSet<get_carousel_imgs> get_carousel_imgs { get; set; }
        public virtual DbSet<get_zimmer_imgs> get_zimmer_imgs { get; set; }
    
        [DbFunction("alpensternEntities2", "uf_GastAnfrageDetails")]
        public virtual IQueryable<uf_GastAnfrageDetails_Result> uf_GastAnfrageDetails(Nullable<int> gastid, Nullable<int> anfrageid)
        {
            var gastidParameter = gastid.HasValue ?
                new ObjectParameter("gastid", gastid) :
                new ObjectParameter("gastid", typeof(int));
    
            var anfrageidParameter = anfrageid.HasValue ?
                new ObjectParameter("anfrageid", anfrageid) :
                new ObjectParameter("anfrageid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<uf_GastAnfrageDetails_Result>("[alpensternEntities2].[uf_GastAnfrageDetails](@gastid, @anfrageid)", gastidParameter, anfrageidParameter);
        }
    
        public virtual int register_user_insert(string benutzername, string passwort, string salt)
        {
            var benutzernameParameter = benutzername != null ?
                new ObjectParameter("benutzername", benutzername) :
                new ObjectParameter("benutzername", typeof(string));
    
            var passwortParameter = passwort != null ?
                new ObjectParameter("passwort", passwort) :
                new ObjectParameter("passwort", typeof(string));
    
            var saltParameter = salt != null ?
                new ObjectParameter("salt", salt) :
                new ObjectParameter("salt", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("register_user_insert", benutzernameParameter, passwortParameter, saltParameter);
        }
    }
}
