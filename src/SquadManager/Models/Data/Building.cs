using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquadManager.Models.Data
{
    public class Building : Models.IBuildRepository
    {
        public IEnumerable<BuildModel> AllBuilds
        {
            get
            {
              List<DB.Build> lr =  SquadManager.DB.Connection.Current.getBuild("");
                List<BuildModel> res = new List<BuildModel>();
                foreach (DB.Build item in lr)
                {
                    res.Add(new BuildModel(item.IDBuild, item.Nom, item.Desctiption, (BuildModel.Profession)item.IDClasse, item.Link, item.Validé, DB.Connection.Current.getPlayerByID(item.IDCreator).NomJoueur, item.IDRole.ToString()));
                }
                return res;
            }
        }

        public void Add(BuildModel item)
        {
            SquadManager.DB.Connection.Current.AddBuild(item.Name
                , item.Link
                , item.NomCreateur
                , item.Class.ToString()
                , item.Role
                , item.Validate
                , item.Description);
        }

        public BuildModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool TryDelete(int id)
        {
            throw new NotImplementedException();
        }

        public bool TryUpdate(BuildModel toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
