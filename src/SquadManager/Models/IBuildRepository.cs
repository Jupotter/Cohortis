using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquadManager.Models
{
    public interface IBuildRepository
    {
        IEnumerable<BuildModel> AllBuilds { get; }
        void Add(BuildModel item);
        BuildModel GetById(int id);
        bool TryDelete(int id);
        bool TryUpdate(BuildModel toUpdate);

    }
}
