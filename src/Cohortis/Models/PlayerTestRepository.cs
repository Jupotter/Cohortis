using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cohortis.Models
{
    public class PlayerTestRepository : IPlayerRepository
    {
        readonly List<PlayerModel> items = new List<PlayerModel>()
        {
            new PlayerModel { Id = 1, Name="Jupotter" },
            new PlayerModel { Id = 2, Name="Nilun" }
        };

        public PlayerTestRepository()
        {
            var player1 = items[0];

            player1.Build.Add(new BuildModel() { Id = 1, Name = "Lance FLAAAAMES", Class = BuildModel.Classe.Engineer});
            player1.Build.Add(new BuildModel() { Id = 2, Name = "You Shall Not Pass!", Class = BuildModel.Classe.Warrior});
        }

        public IEnumerable<PlayerModel> AllPlayers
        {
            get
            {
                return items;
            }
        }

        public void Add(PlayerModel item)
        {
            item.Id = 1 + items.Max(x => (int?)x.Id) ?? 0;
            items.Add(item);
        }

        public PlayerModel GetById(int id)
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
