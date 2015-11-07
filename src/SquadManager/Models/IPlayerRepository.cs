using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquadManager.Models
{
    public interface IPlayerRepository
    {
        IEnumerable<PlayerModel> AllPlayers{ get; }
        void Add(PlayerModel item);
        PlayerModel GetById(int id);
        bool TryDelete(int id);
    }
}
