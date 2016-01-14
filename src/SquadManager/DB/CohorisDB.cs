using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Common;
using MySql.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SquadManager.DB
{
    [DbConfigurationType(typeof (MySql.Data.Entity.MySqlEFConfiguration))]
    public class CohorisDB:DbContext
    {
        public DbSet<joueur> Joueur
        { get; set; }
        public DbSet<Build> lBuild { get; set; }
        public DbSet<BuildJoue> lBJouer { get; set; }
        public DbSet<Classe> lClasse { get; set; }
        public DbSet<Role> lRole { get; set; }

        public CohorisDB():base()
        {

        }

        public CohorisDB(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {
        }
    }
    public class joueur
    {

        [Key]public int IDJoueur { get; set; }
        public string NomJoueur { get; set; }
        public bool Lead { get; set; }  
    }
    public class Build
    {
     [Key]public int IDBuild { get; set; }
        public string Nom { get; set; }
        public string Link { get; set; }
        public int IDCreator { get; set; }
        public int IDClasse { get; set; }
        public int IDRole { get; set; }
        public bool Validé { get; set; }
        public string Desctiption { get; set; }
    }
    public class BuildJoue
    {
        [Key]public int IDJoueur { get; set; }
        public int IDBuild { get; set; }

    }
    public class Classe
    {
        [Key]public int ID { get; set; }
        public string Nom { get; set; }
        public string CA { get; set; }
    }
    public class Role
    {
        [Key]public int ID { get; set; }
        public string Nom { get; set; }
    }
}
