using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquadManager.Models
{
    public class BuildModel
    {
        public enum Profession
        {
            Mesmer,
            Warrior,
            Guardian,
            Engineer,
            Ranger,
            Thief,
            Elementalist,
            Necromancer,
            Revenant
        }

        public BuildModel()
        {
            Id = 0;
        }

        public BuildModel (int id,string name,string description,Profession prof,string link,bool valid,string nomCreateur,string role)
        {
            Id = id;
            Name = name;
            Description = description;
            Class = prof;
            Link = link;
        }

        public void Update()
        {
            DB.Connection.Current.UpdateBuild(convertToDBStandart());
        }

        DB.Build convertToDBStandart()
        {
            return new DB.Build()
            {
                Nom = Name,
                IDBuild = Id,
                IDCreator = DB.Connection.Current.getPlayerId(NomCreateur),
                IDClasse = DB.Connection.Current.getClasseID(Class.ToString()),
                Link = Link,
                IDRole = DB.Connection.Current.getRoleID(Role),
                Validé = Validate,
                Desctiption = Description
            };
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public bool Validate { get; set; }
        public string NomCreateur { get; set; }
        public string Role { get; set; }
        public Profession Class { get; set; }
       

    }
}
