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
            Necromancer
        }

        public BuildModel()
        {
            Id = 0;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Profession Class { get; set; }
    }
}
