using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquadManager.Models
{
    public class PlayerTestRepository : IPlayerRepository
    {
        readonly List<PlayerModel> items = new List<PlayerModel>();

        public PlayerTestRepository(IBuildRepository builds)
        {
            var player = new PlayerModel { Name = "Jupotter" };
            player.Build.Add(builds.GetById(0));
            player.Build.Add(builds.GetById(1));
            Add(player);
            player = new PlayerModel { Name = "Nilun" };
            player.Build.Add(builds.GetById(2));
            player.Build.Add(builds.GetById(3));
            player.Build.Add(builds.GetById(1));
            Add(player);
            player = new PlayerModel { Name = "Smurfi" };
            player.Build.Add(builds.GetById(4));
            Add(player);
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

        public bool Update(PlayerModel item)
        {
            if (items.Any(x => x.Id == item.Id))
            {
                items[item.Id] = item;
                return true;
            }
            return false;
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
