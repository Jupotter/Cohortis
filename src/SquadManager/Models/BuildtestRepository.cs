using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquadManager.Models
{
    public class BuildTestRepository : IBuildRepository
    {
        readonly List<BuildModel> items = new List<BuildModel>();


        public BuildTestRepository()
        {
            Add(new BuildModel() { Name = "Lance FLAAAAMES", Class = BuildModel.Profession.Engineer });
            Add(new BuildModel() { Name = "You Shall Not Pass!", Class = BuildModel.Profession.Warrior });
            Add(new BuildModel() { Name = "GivroFearoMancer", Class = BuildModel.Profession.Necromancer });
            Add(new BuildModel() { Name = "Auramancer", Class = BuildModel.Profession.Elementalist,
            Description=
@"En combat: 
Spam pouvoir, protection, vigueur, soins, rapidité, regen.
Partage ses aura"});
            Add(new BuildModel() { Name = "J'aime pas les drones", Class = BuildModel.Profession.Engineer });
        }

        public IEnumerable<BuildModel> AllBuilds
        {
            get
            {
                return items;
            }
        }

        public void Add(BuildModel item)
        {
            item.Id = 1 + items.Max(x => (int?)x.Id) ?? 0;
            items.Add(item);
        }

        public BuildModel GetById(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        public bool TryDelete(int id)
        {
            var item = GetById(id);
            if (item == null)
            {
                return false;
            }
            items.Remove(item);
            return true;
        }
    }
}
