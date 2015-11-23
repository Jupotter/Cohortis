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
        public List<Build> lBuild = new List<Build>();
        public List<BuildJoue> lBJouer = new List<BuildJoue>();
        public List<Classe> lClasse = new List<Classe>();
        public List<Role> lRole = new List<Role>();

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
        public int IDBuild { get; set; }
        public string Nom { get; set; }
        public string Link { get; set; }
        public int IDCreator { get; set; }
        public int IDClasse { get; set; }
        public int IDRole { get; set; }
        public bool Validé { get; set; }
    }
    public class BuildJoue
    {
        public int IDJoueur { get; set; }
        public int IDBuild { get; set; }

    }
    public class Classe
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string CA { get; set; }
    }
    public class Role
    {
        public int ID { get; set; }
        public string Nom { get; set; }
    }
}
