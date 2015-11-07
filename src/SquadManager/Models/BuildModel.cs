using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquadManager.Models
{
    public class BuildModel
    {
        public enum Classe
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

        public int Id { get; set; }
        public string Name { get; set; }
        public Classe Class { get; set; }
    }
}
